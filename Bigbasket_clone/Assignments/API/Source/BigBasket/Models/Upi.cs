using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Upi
    {
        public int UpiId { get; set; }
        public int? AccountId { get; set; }
        public bool? ActiveFlag { get; set; }
        public DateTime? UpiAddedDate { get; set; }
        public DateTime? UpiModifiedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
