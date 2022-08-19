using System;

namespace FridgeProducts.Contracts.Dto
{
    public class FridgeProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? DefaultQuantity { get; set; }
    }
}
