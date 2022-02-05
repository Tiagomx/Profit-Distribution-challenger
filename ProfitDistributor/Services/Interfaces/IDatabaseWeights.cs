using ProfitDistributor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IDatabaseWeights
    {
        Task<List<PFSModel>> GetAllPFSAsync();

        Task<List<PTAModel>> GetAllPTAAsync();

        Task<List<PAAModel>> GetAllPAAAsync();
    }
}