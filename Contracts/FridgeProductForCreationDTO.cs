using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeProducts.Contracts.Dto
{
    public class FridgeProductForCreationDTO
    {

        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid ProductId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity is required and it can't be lower than 0")]
        public int Quantity { get; set; }
    }
}
