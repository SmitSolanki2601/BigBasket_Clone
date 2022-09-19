using System;
using System.Collections.Generic;

#nullable disable

namespace BigBasket.Models
{
    public partial class Type
    {
        public Type()
        {
            Objects = new HashSet<Object>();
        }

        public int TypeId { get; set; }
        public string TypeValue { get; set; }
        public DateTime? TypeAddedDate { get; set; }
        public DateTime? TypeModifiedDate { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
