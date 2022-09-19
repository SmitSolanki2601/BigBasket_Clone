using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? UpiId { get; set; }
        public DateTime? PaymentsAddedDate { get; set; }
        public DateTime? PaymentsModifiedDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
