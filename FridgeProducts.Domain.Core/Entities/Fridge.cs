using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProducts.Domain.Core.Entities
{
    [Table("fridge")]
    public class Fridge
    {
        [Column("FridgeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }

        [ForeignKey(nameof(FridgeModel))]
        public Guid FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
