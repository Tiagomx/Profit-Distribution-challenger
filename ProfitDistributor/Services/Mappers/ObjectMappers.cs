using System.Collections.Generic;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistritor.Services.Mappers
{
    public class ObjectMappers : IObjectMappers
    {
        public ObjectMappers()
        {
        }

        public Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance)
        {
            return new Summary
            {
                Distributions = employeeDistributions,
                TotalEmployees = numberOfEmployees,
                DistributedAmount = CurrencyFormatMoneyUtils.SetMoneyTextFromDecimal(totalDistributed),
                DistributionAmountBalance = CurrencyFormatMoneyUtils.SetMoneyTextFromDecimal(distributionAmountBalance),
                AvailableAmount = CurrencyFormatMoneyUtils.SetMoneyTextFromDecimal(totalAmount)
            };
        }

        public EmployeeDistribution MapEmployeeToEmployeeDistribution(Employee employee, decimal distributionAmount)
        {
            return new EmployeeDistribution
            {
                RegistrationId = employee.RegistrationId,
                Name = employee.Name,
                DistributionAmount = CurrencyFormatMoneyUtils.SetMoneyTextFromDecimal(distributionAmount)
            };
        }
    }
}