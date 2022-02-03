using System.Collections.Generic;

using ProfitDistributor.Domain.Entities;

namespace ProfitDistritor.Domain.Mappers
{
    public interface IObjectMappers
    {
        Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance);

        EmployeeDistribution MapEmployeeToEmployeeDistribution(Funcionario employee, decimal distributionAmount);
    }
}