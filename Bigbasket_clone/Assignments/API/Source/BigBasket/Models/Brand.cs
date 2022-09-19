using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public DateTime? BrandAddedDate { get; set; }
        public DateTime? BrandModifiedDate { get; set; }
        public bool? ActiveField { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
