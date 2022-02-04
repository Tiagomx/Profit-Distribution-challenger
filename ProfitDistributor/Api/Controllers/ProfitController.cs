//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProfitDistributorHelper.Domain.Models;
//using ProfitDistributorHelper.Services.Application;

//namespace ProfitDistributor.Application.Controllers
//{
//    [ApiController]
//    [Route("api/profit-dist")]
//    public class ProfitController : ControllerBase
//    {
//        private readonly IProfitService profitService;

//        public ProfitController(IProfitService service)
//        {
//            profitService = service;
//        }

//        [HttpGet]
//        [Route("employees/profit")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<Summary>> CalculateProfitGetAsync([FromQuery] decimal totalAmount)
//        {
//            return await profitService.GetSummaryForProfitDistributionAsync(totalAmount);
//        }

//        [HttpGet]
//        [Route("employees")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<List<Employee>> GetEmployeeListAsync()
//        {
//            return await profitService.GetEmployeesAsync();
//        }

//        [HttpPost]
//        [Route("postEmployees")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<Employee>> PostEmployeesToFirebaseAsync([FromQuery] Employee emp)
//        {
//            return Ok(await profitService.PostEmployeesAsync(emp));
//        }
//    }
//}