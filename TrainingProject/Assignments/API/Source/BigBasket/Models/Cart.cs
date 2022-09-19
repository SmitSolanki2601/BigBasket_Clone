using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CartCreateDate { get; set; }
        public DateTime? CartModifiedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
