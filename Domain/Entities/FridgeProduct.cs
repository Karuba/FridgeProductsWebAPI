using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("fridge_products")]
    public class FridgeProduct
    {
        [Column("FridgeProductId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity is required and it can't be lower than 0")]
        public int Quantity { get; set; }
    }
}
