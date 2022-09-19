using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderItemAddedDate { get; set; }
        public DateTime? OrderModifiedDate { get; set; }
        public bool? ActiveFlag { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
