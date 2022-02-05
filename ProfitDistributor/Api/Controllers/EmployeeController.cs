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
        private readonly IEmployeeService _funionario;
        //private readonly IProfitService _profitService;

        public EmployeeController(IEmployeeService Employee/*, IProfitService profitService*/)
        {
            _funionario = Employee;
        }

        [HttpGet]
        public Task<List<Employee>> Get()
        {
            return _funionario.GetEmployeesAsync();
        }

        [HttpGet("{id}")]
        public Task<Employee> Get(string id)
        {
            return _funionario.GetEmployeeById(id);
        }

        [HttpPost]
        public void Post([FromBody] Employee Employee)
        {
            _funionario.AddEmployee(Employee);
        }

        [HttpPut]
        public void Put([FromBody] Employee Employee)
        {
            _funionario.UpdateEmployee(Employee);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _funionario.DeleteEmployee(id);
        }
    }
}