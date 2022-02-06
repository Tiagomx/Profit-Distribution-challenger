using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProfitDistributor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        private readonly IProfitService _profitService;

        public EmployeeController(IEmployeeService Employee, IProfitService profitService)
        {
            _employee = Employee;
            _profitService = profitService;
        }

        [HttpGet]
        [Route("Profit")]
        public Task<ActionResult<Summary>> CalculateProfitGetAsync([FromQuery] decimal totalAmount)
        {
            return _profitService.GetSummaryForProfitDistributionAsync(totalAmount);
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