using Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTests.Mocks
{
    public class FakeRepositoryManager
    {
        public Mock<IRepositoryManager> Mock;
        public IRepositoryManager Repository;
        public FakeRepositoryManager()
        {
            Mock = new Mock<IRepositoryManager>();

            Repository = Mock.Object;
        }
    }
}
