using System.Collections.Generic;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;

namespace ProfitDistritor.Services.Mappers
{
    public class ObjectMappers : IObjectMappers
    {
        public ObjectMappers()
        {
        }

        public Summary MapResultToSummary(List<DistribuicaoDeValores> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance)
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

        public DistribuicaoDeValores MapEmployeeToEmployeeDistribution(Funcionario employee, decimal distributionAmount)
        {
            return new DistribuicaoDeValores
            {
                Matricula = employee.Id,
                Nome = employee.Nome,
                ValorParticipacao = CurrencyFormatMoneyUtils.SetMoneyTextFromDecimal(distributionAmount)
            };
        }
    }
}