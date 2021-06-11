using ComputerShop.API.Services.Abstracts;
using Moq;

namespace ComputerShop.Tests.Mocks
{
    public class LaptopFakeService
    {
        public Mock<ILaptopService> Mock;
        public ILaptopService Service;

        public LaptopFakeService()
        {
            Mock = new Mock<ILaptopService>();

            Service = Mock.Object;
        }
    }
}
