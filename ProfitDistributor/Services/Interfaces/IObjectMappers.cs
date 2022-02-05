using System.Collections.Generic;

using ProfitDistributor.Domain.Entities;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IObjectMappers
    {
        Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance);

        EmployeeDistribution MapEmployeeToEmployeeDistribution(Employee employee, decimal distributionAmount);
    }
}