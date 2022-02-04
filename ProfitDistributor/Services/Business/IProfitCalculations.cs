using ProfitDistributor.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Services.Business
{
    public interface IProfitCalculations
    {
        Task<List<DistribuicaoDeValores>> DistributeProfitForEmployeesAsync(List<Funcionario> employees);
    }
}