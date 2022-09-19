using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Order
    {
        public Order()
        {
            CartDetails = new HashSet<CartDetail>();
            OrderItems = new HashSet<OrderItem>();
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? OrderStatusId { get; set; }
        public decimal? OrderAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalDiscountAmount { get; set; }
        public decimal? PayableAmount { get; set; }
        public int? PaymentMethod { get; set; }
        public DateTime? OrderModifiedDate { get; set; }
        public bool? ActiveFlag { get; set; }

        public virtual Object OrderStatus { get; set; }
        public virtual Object PaymentMethodNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
