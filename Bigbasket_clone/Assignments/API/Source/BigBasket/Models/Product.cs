using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace BigBasket.Models
{
    public partial class Product
    {
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
            Discounts = new HashSet<Discount>();
            OrderItems = new HashSet<OrderItem>();
            ProductDetails = new HashSet<ProductDetail>();
        }
    
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public decimal Price { get; set; }
        public int? ProductUnitOfWeightId { get; set; }
        public DateTime? ProductAddedDate { get; set; }
        public DateTime? ProductModifiedDate { get; set; }
        public bool? ActiveField { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Object ProductUnitOfWeight { get; set; }
        [JsonIgnore]
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<Discount> Discounts { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }

    public class productDisplayDTO {
        [Required]
        public string productName { get; set; }
        [Required]
        public string brand { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public decimal price { get; set; }

        public string ProductImgUrl { get; set; }

        public string ProductColour { get; set; }
        public string CountryOfOrigin { get; set; }

    }
    public class SearchProductDTO
    {
        [Required]
        public string productName { get; set; }

    }
}
