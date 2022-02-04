using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using ProfitDistributor.Domain.Entities;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IProfitService
    {
        Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount);

        Task<List<Funcionario>> GetEmployeesAsync();

        Task<HttpResponseMessage> PostEmployeesAsync(Funcionario employee);
    }
}