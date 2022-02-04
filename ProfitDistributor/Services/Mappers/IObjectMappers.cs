using System.Collections.Generic;

using ProfitDistributor.Domain.Entities;

namespace ProfitDistritor.Services.Mappers
{
    public interface IObjectMappers
    {
        Summary MapResultToSummary(List<DistribuicaoDeValores> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance);

        DistribuicaoDeValores MapEmployeeToEmployeeDistribution(Funcionario employee, decimal distributionAmount);
    }
}