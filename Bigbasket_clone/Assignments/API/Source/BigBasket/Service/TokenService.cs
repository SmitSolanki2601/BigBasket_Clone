using BigBasket.IService;
using BigBasket.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BigBasket.Service
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }



        public string CreateToken(User user)
        {
            //CREATE USER CLAIMS
            var userclaims = new List<Claim>
            {
                  new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, "User")
            };

            var usercreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);   // SIGNING TOKEN

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userclaims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = usercreds
            };

            var tokenhandler = new JwtSecurityTokenHandler();

            //CREATE TOKEN
            var usertoken = tokenhandler.CreateToken(tokenDescriptor);

            return tokenhandler.WriteToken(usertoken);
        }


        public string CreateToken(Admin admin)
        {
            //CREATE Admin CLAIMS
            var adminclaims = new List<Claim>
            {
                  new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, "admin")
            };


            var admincreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);   // SIGNING TOKEN

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(adminclaims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = admincreds
            };

            var tokenhandler = new JwtSecurityTokenHandler(); ;

            //CREATE TOKEN
            var admintoken = tokenhandler.CreateToken(tokenDescriptor);

            return tokenhandler.WriteToken(admintoken);
        }
    }
}