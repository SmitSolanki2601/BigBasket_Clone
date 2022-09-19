using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class UserProfile
    {
        public int ProfileId { get; set; }
        public int? UserId { get; set; }
        public string ProfilePic { get; set; }
        public decimal? Wallet { get; set; }
        public int? AddressId { get; set; }
        public DateTime? ProfileUpdateDate { get; set; }
        public DateTime? ProfileModifiedDate { get; set; }
        public bool? ActiveField { get; set; }

        public virtual UserAddress Address { get; set; }
        public virtual User User { get; set; }
    }
}
