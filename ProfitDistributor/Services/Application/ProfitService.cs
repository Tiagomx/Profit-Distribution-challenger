using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase.Database;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Services.Business;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;
using ProfitDistributor.Services.Interfaces;

using ProfitDistributorHelper.Services.Repositories;

using ProfitDistritor.Services.Mappers;

namespace ProfitDistributorHelper.Services.Application
{
    public class ProfitService : IProfitService
    {
        private const string ERROR_BALANCE = "Saldo insuficiente para distribuição";
        private readonly IDatabaseFuncionarios databaseEmployees;
        private readonly IProfitCalculations profitCalculations;
        private readonly IObjectMappers objectMappers;

        public object MoneyUtils { get; private set; }

        // Performing Dependency Injection
        public ProfitService(IDatabaseFuncionarios database, IObjectMappers mappers, IProfitCalculations profitCalcs)
        {
            databaseEmployees = database;
            objectMappers = mappers;
            profitCalculations = profitCalcs;
        }

        public async Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount)
        {
            var employees = await GetEmployeesAsync();
            List<DistribuicaoDeValores> employeeDistributions = await profitCalculations.DistributeProfitForEmployeesAsync(employees.ToList());
            decimal totalDistributed = employeeDistributions.Sum(emp => CurrencyFormatMoneyUtils.SetDecimalFromString(emp.ValorParticipacao));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);

            if (IsNegative(distributionAmountBalance))
            {
                return new BadRequestObjectResult(ERROR_BALANCE);
            }

            return objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance);
        }

        public async Task<List<Funcionario>> GetEmployeesAsync()
        {
            return await databaseEmployees.FetchAllFuncionariosAsync();
        }

        public async Task<HttpResponseMessage> PostEmployeesAsync(Funcionario employee)
        {
            return await databaseEmployees.PostToFireBaseEmployeesAsync(employee);
        }

        private bool IsNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}