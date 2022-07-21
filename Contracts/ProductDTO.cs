using System;

namespace FridgeProducts.Contracts.Dto
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
    }
}
