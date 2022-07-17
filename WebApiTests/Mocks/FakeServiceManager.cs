using Domain.Repositories;
using Moq;
using Services.Abstractions;

namespace WebApiTests.Mocks
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
