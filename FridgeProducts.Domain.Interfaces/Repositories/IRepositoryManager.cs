using System.Threading.Tasks;

namespace FridgeProducts.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IFridgeModelRepository FridgeModel { get; }
        IFridgeRepository Fridge { get; }
        IFridgeProductRepository FridgeProduct { get; }
        Task SaveAsync();
    }
}
