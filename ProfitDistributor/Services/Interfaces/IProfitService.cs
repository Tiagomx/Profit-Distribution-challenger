using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfitDistributor.Domain.Entities;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IProfitService
    {
        Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount);
    }
}