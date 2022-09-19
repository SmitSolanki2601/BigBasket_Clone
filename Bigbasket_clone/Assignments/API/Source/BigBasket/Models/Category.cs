using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace BigBasket.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    
        public int? ParentId { get; set; }
        [Required]
        public DateTime? CatAddedDate { get; set; }
        public DateTime? CatModifiedDate { get; set; }
           [Required]
        public int? Level { get; set; }
        public bool? ActiveField { get; set; }

        [JsonIgnore]
        public virtual Category Parent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Category> InverseParent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class adminCategoryDisplayDTO
    {

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        
        public int? ParentId { get; set; }

        public DateTime? CatAddedDate { get; set; }

    }
}
