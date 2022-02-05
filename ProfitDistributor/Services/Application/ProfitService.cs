using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistributor.Services.Application
{
    public class ProfitService : IProfitService
    {
        private const string ERROR_BALANCE = "Saldo insuficiente para distribuição";
        private readonly IEmployeeService employeeService;
        private readonly IProfitCalculations profitCalculations;
        private readonly IObjectMappers objectMappers;

        public object MoneyUtils { get; private set; }

        // Performing Dependency Injection
        public ProfitService(IEmployeeService database, IObjectMappers mappers, IProfitCalculations profitCalcs)
        {
            employeeService = database;
            objectMappers = mappers;
            profitCalculations = profitCalcs;
        }

        public async Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount)
        {
            var employees = await employeeService.GetEmployeesAsync();
            List<EmployeeDistribution> employeeDistributions = await profitCalculations.DistributeProfitForEmployeesAsync(employees.ToList());
            decimal totalDistributed = employeeDistributions.Sum(emp => CurrencyFormatMoneyUtils.SetDecimalFromString(emp.DistributionAmount));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);

            if (IsNegative(distributionAmountBalance))
            {
                return new BadRequestObjectResult(ERROR_BALANCE);
            }

            return objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await employeeService.GetEmployeesAsync();
        }

        private bool IsNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}