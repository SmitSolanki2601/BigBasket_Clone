using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class City
    {
        public City()
        {
            UserAddresses = new HashSet<UserAddress>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }
        public DateTime? CityAddedDate { get; set; }
        public DateTime? CityModifiedDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
