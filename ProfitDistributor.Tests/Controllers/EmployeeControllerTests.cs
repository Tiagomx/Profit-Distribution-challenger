using Moq;
using ProfitDistributor.Api.Controllers;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistributor.Tests.Controllers
{
    public class EmployeeControllerTests : ProfitControllerTestsBase
    {
        [Fact]
        public async Task EmployeeControllerTest_GetEmployees()
        {
            var mockService = new Mock<IEmployeeService>();
            var mockServiceProfi = new Mock<IEmployeeService>();
            mockService.Setup(service => service.GetEmployeesAsync())
                .ReturnsAsync(GetListOfEmployeesMock());
            var controller = new EmployeeController(mockService.Object);

            var result = await controller.Get();

            Assert.Equal(2, result.Count);
        }
    }
}