using BigBasket.IService;
using BigBasket.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BigBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public bigbasket2406smitContext DbContext { get; }
        public ITokenService TokenService { get; }

        public AccountController(bigbasket2406smitContext dBContext,ITokenService tokenService)
        {
            DbContext = dBContext;
            TokenService = tokenService;
        }



        [HttpPost("Register")]

        public ActionResult Register([FromBody] UserRegisterDTO user)
        {
            if (AdminExist(user.Email, user.PhoneNumber))
                return BadRequest("Email or Phone Number already Registered !!");

            if (UserExist(user.Email,user.PhoneNumber))
                return BadRequest("Email or Phone Number already Registered !!");

            using var hmac = new HMACSHA512();


            var appUser = new User
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                PhoneNumber = user.PhoneNumber,
                GenderId = user.GenderID,
                Email = user.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.password)),
                PasswordSalt = hmac.Key,
                //UserRegisterDate =  DateTime.Now
            };
            
            DbContext.Add(appUser);
             DbContext.SaveChanges();

            return Ok($"USER REGISTERED WITH ID {appUser.UserId}");
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserSigningDTO userSigning)
        {
            var admin = await DbContext.Admins.SingleOrDefaultAsync(X =>X.Email == userSigning.Email);

          
            if (admin == null)
            {
                var user = await DbContext.Users.SingleOrDefaultAsync(X => X.Email == userSigning.Email);

                if (user == null) { return BadRequest(new { message= "Please Register Your Self First !!! UserName Not Found." }); }

                else
                {
                    using var hmac = new HMACSHA512(user.PasswordSalt);

                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userSigning.password));

                    for(int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != user.PasswordHash[i])
                        {
                            return Unauthorized(new { message = "Invalid Pasword... Please Try Again !!!" });
                        }
                    }

                    return Ok(new UserDTO { Email = user.Email, Token = TokenService.CreateToken(user), role = "User" });
                }
            }
            else
            {
                using var hmac = new HMACSHA512(admin.PasswordSalt);

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userSigning.password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != admin.PasswordHash[i])
                    {
                        return Unauthorized("Invalid Pasword... Please Try Again !!!");
                    }
                }

                return Ok(new AdminDTO { Email = admin.Email, Token = TokenService.CreateToken(admin) , role = "Admin" });
            }
        }

        private bool UserExist(string Email,string phonenumber)
        {
            return DbContext.Users.Any(x => x.Email == Email || x.PhoneNumber == phonenumber);
        }
        private bool AdminExist(string Email, string phonenumber)
        {
            return DbContext.Admins.Any(x => x.Email == Email || x.PhoneNumber == phonenumber);
        }


        //private bool ValidateUSer(string usercred)
        //{
        //    return DbContext.Users.Any(x => x.Email == usercred /*|| x.PhoneNumber == phonenumber*/);       // CAN SIGNIN WITH 2 Options... Phone Number OR Email ID
        //}
        //private bool ValidateAdmin(string admincred)
        //{
        //    return DbContext.Admins.Any(x => x.Email == admincred /*||/* x.PhoneNumber == admincred*/);
        //}
    }
}
