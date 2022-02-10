using ProfitDistributor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProfitDistributor.Tests.Controllers
{
    public class ProfitControllerTestsBase
    {
        public List<Employee> GetListOfEmployeesMock()
        {
            return new List<Employee>
            {
                new Employee
                {
                    RegistrationId = "12345",
                    Name = "John Doe",
                    Area = "Diretoria",
                    Position = "Funcionario",
                    Salary = "R$ 1.234,00",
                    AdmissionDate = DateTime.Parse("2010-08-05").ToString()
                },
                new Employee
                {
                    RegistrationId = "67890",
                    Name = "Jane Smith",
                    Area = "Financeiro",
                    Position = "Funcionario",
                    Salary = "R$ 1.543,00",
                    AdmissionDate = DateTime.Parse("2009-08-05").ToString()
                },
            };
        }
    }
}