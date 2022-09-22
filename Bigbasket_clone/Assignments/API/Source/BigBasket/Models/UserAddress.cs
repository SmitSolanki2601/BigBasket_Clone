using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public int? CityId { get; set; }
        public int? Zip { get; set; }
        public DateTime? UserAddressAddedDate { get; set; }
        public DateTime? UserAddressModifiedDate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
