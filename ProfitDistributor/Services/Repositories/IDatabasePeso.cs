using ProfitDistribution.Domain.Models.Profit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistributorHelper.Services.Repositories
{
    public interface IDatabasePeso
    {
        Task<List<PFSModel>> FetchAllPFSAsync();

        Task<List<PTAModel>> FetchAllPTAAsync();

        Task<List<PAAModel>> FetchAllPAAAsync();
    }
}