using ComputerShop.Data.Repositories;
using Moq;

namespace ComputerShop.Tests.Mocks
{
    public class LaptopFakeRepository
    {
        public Mock<ILaptopRepository> Mock;
        public ILaptopRepository Repository;

        public LaptopFakeRepository()
        {
            Mock = new Mock<ILaptopRepository>();

            Repository = Mock.Object;
        }
    }
}
