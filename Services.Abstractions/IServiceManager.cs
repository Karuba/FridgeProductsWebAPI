namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IFridgeService fridgeService { get; }
        IProductService productService { get; }
    }
}
