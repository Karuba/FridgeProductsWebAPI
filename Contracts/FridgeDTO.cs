using System;

namespace Contracts
{
    public class FridgeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
        public FridgeModelDTO FridgeModel { get; set; }
    }
}
