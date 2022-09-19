using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Object
    {
        public Object()
        {
            Admins = new HashSet<Admin>();
            OrderOrderStatuses = new HashSet<Order>();
            OrderPaymentMethodNavigations = new HashSet<Order>();
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        public int ObjectId { get; set; }
        public int? TypeId { get; set; }
        public string ObjectValue { get; set; }
        public DateTime? ObjectAddedDate { get; set; }
        public DateTime? ObjectModifiedDate { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Order> OrderOrderStatuses { get; set; }
        public virtual ICollection<Order> OrderPaymentMethodNavigations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
