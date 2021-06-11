using AutoMapper;
using ComputerShop.API.Services;
using ComputerShop.API.Services.Abstracts;
using ComputerShop.API.Utils.Mappings;
using ComputerShop.Data.Models;
using ComputerShop.Data.Repositories;
using ComputerShop.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Tests.Tests
{
    [TestClass]
    public class LaptopServiceTests
    {
        private readonly IMapper _mapper;
        public LaptopServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [TestMethod]
        public async Task GetLaptopAsync_Response_WithoutConfigs()
        {
            string guid = Guid.NewGuid().ToString();
            LaptopFakeRepository repository = new LaptopFakeRepository();
            repository.Mock.Setup(s => s.GetAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Laptop()
                {
                    Id = Guid.Parse(guid),
                    Name = "Dell",
                    Price = 10.23
                }));

            LaptopService service = new LaptopService(repository.Repository, null, _mapper);

            var laptop = await service.GetLaptopAsync(Guid.Parse(guid));

            Assert.IsNotNull(laptop);
            Assert.AreEqual(Guid.Parse(guid), laptop.Id);
            Assert.AreEqual("Dell", laptop.Name);
            Assert.AreEqual(10.23, laptop.Price);
            Assert.IsNotNull(laptop.Configurations);
            Assert.AreEqual(0, laptop.Configurations.Count);
        }
    }
}
