using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("fridge_model")]
    public class FridgeModel
    {
        [Column("FridgeModelId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }

        public int? Year { get; set; }

        public ICollection<Fridge> Fridges { get; set; }
    }
}
