//using System.Collections.Generic;
//using ProfitDistributor.Domain.Entities;
//using ProfitDistritor.Domain.Mappers;

//namespace ProfitDistribution.Domain.Mappers
//{
//    public class ObjectMappers : IObjectMappers
//    {
//        public ObjectMappers()
//        {
//        }

//        public Summary MapResultToSummary(List<EmployeeDistribution> employeeDistributions, string numberOfEmployees, decimal totalAmount, decimal totalDistributed, decimal distributionAmountBalance)
//        {
//            return new Summary
//            {
//                Distributions = employeeDistributions,
//                TotalEmployees = numberOfEmployees,
//                DistributedAmount = MoneyUtils.SetMoneyTextFromDecimal(totalDistributed),
//                DistributionAmountBalance = MoneyUtils.SetMoneyTextFromDecimal(distributionAmountBalance),
//                AvailableAmount = MoneyUtils.SetMoneyTextFromDecimal(totalAmount)
//            };
//        }

//        public EmployeeDistribution MapEmployeeToEmployeeDistribution(Funcionario employee, decimal distributionAmount)
//        {
//            return new EmployeeDistribution
//            {
//                RegistrationId = employee.RegistrationId,
//                Name = employee.Name,
//                DistributionAmount = MoneyUtils.SetMoneyTextFromDecimal(distributionAmount)
//            };
//        }
//    }
//}