using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistributor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfitController : ControllerBase
    {
        private readonly IProfitService _profitService;

        public ProfitController(IProfitService service)
        {
            _profitService = service;
        }

        [HttpGet]
        [Route("Calculate")]
        public Task<ActionResult<Summary>> CalculateProfitGetAsync([FromQuery] decimal totalAmount)
        {
            return _profitService.GetSummaryForProfitDistributionAsync(totalAmount);
        }
    }
}