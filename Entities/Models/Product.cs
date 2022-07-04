using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProductsWebAPI.Models
{
    [Table("products")]
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product name is a required field.")]
        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }
        
        public ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
