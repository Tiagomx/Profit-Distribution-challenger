using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistributor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;

        public EmployeeController(IEmployeeService Employee)
        {
            _employee = Employee;
        }

        [HttpGet]
        public Task<List<Employee>> Get()
        {
            return _employee.GetEmployeesAsync();
        }

        [HttpGet("{id}")]
        public Task<Employee> Get(string id)
        {
            return _employee.GetEmployeeById(id);
        }

        [HttpPost]
        public void Post([FromBody] Employee Employee)
        {
            _employee.AddEmployee(Employee);
        }

        [HttpPut]
        public void Put([FromBody] Employee Employee)
        {
            _employee.UpdateEmployee(Employee);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _employee.DeleteEmployee(id);
        }
    }
}