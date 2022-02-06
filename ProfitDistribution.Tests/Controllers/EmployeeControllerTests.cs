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
    public class EmployeeControllerTests
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

        private List<Employee> GetListOfEmployeesMock()
        {
            return new List<Employee>
            {
                new Employee
                {
                    RegistrationId = "12345",
                    Name = "John Doe",
                    Area = "Diretoria",
                    Position = "Diretor Financeiro",
                    Salary = "R$ 1.234,00",
                    AdmissionDate = DateTime.Parse("2010-08-05").ToString()
                },
                new Employee
                {
                    RegistrationId = "67890",
                    Name = "Jane Smith",
                    Area = "Financeiro",
                    Position = "Economista Chefe",
                    Salary = "R$ 1.543,00",
                    AdmissionDate = DateTime.Parse("2009-08-05").ToString()
                },
            };
        }
    }
}