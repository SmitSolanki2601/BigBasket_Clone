using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class CartDetail
    {
        public int CartDetailsId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public int? OrderId { get; set; }
        public int? SavedAmount { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
