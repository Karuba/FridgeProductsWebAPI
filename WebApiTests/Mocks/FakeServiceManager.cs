using Moq;
using Services.Abstractions;

namespace FridgeProducts.Tests.Mocks
{
    public class FakeServiceManager
    {
        public Mock<IServiceManager> Mock;
        public IServiceManager serviceManager;
        public FakeServiceManager()
        {
            Mock = new Mock<IServiceManager>();

            serviceManager = Mock.Object;
        }
    }
}
