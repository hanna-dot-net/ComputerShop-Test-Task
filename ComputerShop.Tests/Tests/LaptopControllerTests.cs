using ComputerShop.API.Controllers;
using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using ComputerShop.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Tests.Tests
{
    [TestClass]
    public class LaptopControllerTests
    {
        [TestMethod]
        public async Task GetLaptopsAsync_ShouldReturnOk_NoData()
        {
            var fakeService = new LaptopFakeService();
            fakeService.Mock.Setup(s => s.GetLaptopListAsync())
                .Returns(Task.FromResult(
                    new LaptopListResponse()));

            LaptopsController controller = new LaptopsController(fakeService.Service);

            var response = await controller.GetLaptopsAsync();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(LaptopListResponse));

            var laptops = okResult.Value as LaptopListResponse;

            Assert.IsNotNull(laptops);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, laptops.ResponseCode);

            Assert.IsNull(laptops.Laptops);
        }

        [TestMethod]
        public async Task GetLaptopsAsync_ShouldReturnOk_WithData()
        {
            var fakeService = new LaptopFakeService();
            fakeService.Mock.Setup(s => s.GetLaptopListAsync())
                .Returns(Task.FromResult(
                    new LaptopListResponse() {
                        Laptops = new List<LaptopModel>()
                        {
                            new LaptopModel()
                            {
                                Name = "Dell",
                                Price = 10.25
                            }
                        }
                    }));

            LaptopsController controller = new LaptopsController(fakeService.Service);

            var response = await controller.GetLaptopsAsync();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response,  typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(LaptopListResponse));

            var laptops = okResult.Value as LaptopListResponse;

            Assert.IsNotNull(laptops);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, laptops.ResponseCode);

            Assert.IsNotNull(laptops.Laptops);
            Assert.AreEqual(1, laptops.Laptops.Count());

            Assert.IsNotNull(laptops.Laptops[0]);
            Assert.AreEqual("Dell", laptops.Laptops[0].Name);
            Assert.AreEqual(10.25, laptops.Laptops[0].Price);
        }

        [TestMethod]
        public async Task AddLaptopAsync_ValidModel_ShouldThrowArgumentException()
        {
            string laptopId = Guid.NewGuid().ToString();

            var fakeService = new LaptopFakeService();
            fakeService.Mock.Setup(s => s.AddLaptopAsync(It.IsAny<AddLaptopModel>()))
                .Returns((AddLaptopModel model) => Task.FromResult(Guid.Parse(laptopId)));

            LaptopsController controller = new LaptopsController(fakeService.Service);

            var request = new AddLaptopModel();

            var response =  await controller.AddLaptopAsync(request);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(CreatedResult));

            var result = response as CreatedResult;

            Assert.AreEqual(201, result.StatusCode);

            Assert.IsNotNull(result.Value);
            Assert.IsInstanceOfType(result.Value, typeof(AddedResponse));

            var addedResult = result.Value as AddedResponse;

            Assert.IsNotNull(addedResult);
            Assert.AreEqual(System.Net.HttpStatusCode.Created, addedResult.ResponseCode);

            Assert.IsNotNull(addedResult.Id);
            Assert.AreEqual(Guid.Parse(laptopId), addedResult.Id);
        }
    }
}
