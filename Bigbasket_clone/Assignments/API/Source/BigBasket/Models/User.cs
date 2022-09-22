using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BigBasket.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            UserProfiles = new HashSet<UserProfile>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GenderId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? UserRegisterDate { get; set; }
        public DateTime? UserModifiedDate { get; set; }
        public bool? ActiveFlag { get; set; }

        public virtual Object Gender { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }


    public class UserSigningDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string role { get; set; }
    }

    public class UserRegisterDTO
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string PhoneNumber { get; set; }
        public int GenderID { get; set; }

        public string Email { get; set; }

        public string password { get; set; }
    }


}
