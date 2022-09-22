using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public int? ProductId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? DiscountStartDate { get; set; }
        public DateTime? DiscountEndDate { get; set; }
        public DateTime? DiscountAddedDate { get; set; }
        public DateTime? DiscountsModifiedDate { get; set; }
        public bool? ActiveField { get; set; }

        public virtual Product Product { get; set; }
    }
}
