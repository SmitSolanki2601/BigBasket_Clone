using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class ProductDetail
    {
        public int ProductDetailsId { get; set; }
        public int? ProductId { get; set; }
        public string ProductDiscription { get; set; }
        public string ProductImgUrl { get; set; }
        public string ProductColour { get; set; }
        public string CountryOfOrigin { get; set; }
        public int? StockCount { get; set; }
        public string Season { get; set; }

        public virtual Product Product { get; set; }
    }
}
