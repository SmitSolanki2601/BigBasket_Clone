using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? GenderId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? AdminRegisterDate { get; set; }
        public DateTime? AdminModifiedDate { get; set; }
        public bool? ActiveField { get; set; }

        public virtual Object Gender { get; set; }
    }

    public class AdminDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public string role { get; set; }
    }

}
