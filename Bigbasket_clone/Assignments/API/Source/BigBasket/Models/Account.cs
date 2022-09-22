using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Account
    {
        public Account()
        {
            Upis = new HashSet<Upi>();
        }

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public int? UserId { get; set; }
        public DateTime? AccountAddedDate { get; set; }
        public DateTime? AccountModifiedDate { get; set; }
        public bool? ActiveFlag { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Upi> Upis { get; set; }
    }
}
