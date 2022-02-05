using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfitDistribution.Domain.Models.Profit;

using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;
using ProfitDistributor.Services.Interfaces;
using ProfitDistributorHelper.Services.Repositories;
using ProfitDistritor.Services.Mappers;

namespace ProfitDistributor.Services.Business
{
    public class ProfitCalculations : IProfitCalculations
    {
        private readonly IDatabasePeso databaseWeights;
        private readonly IObjectMappers objectMappers;

        public ProfitCalculations(IDatabasePeso database, IObjectMappers mappers)
        {
            databaseWeights = database;
            objectMappers = mappers;
        }

        public async Task<List<EmployeeDistribution>> DistributeProfitForEmployeesAsync(List<Employee> funcionarios)
        {
            List<EmployeeDistribution> employeeDistributions = new List<EmployeeDistribution>();

            List<PFSModel> pfsList = await databaseWeights.FetchAllPFSAsync();
            List<PTAModel> ptaList = await databaseWeights.FetchAllPTAAsync();
            List<PAAModel> paaList = await databaseWeights.FetchAllPAAAsync();
            Dictionary<string, decimal> paaDict = paaList.ToDictionary(x => x.Area, x => x.Weight);

            funcionarios.ForEach(employee => employeeDistributions.Add(objectMappers.MapEmployeeToEmployeeDistribution(employee, CalculateProfitDistributionForEmployee(employee, pfsList, ptaList, paaDict))));

            return employeeDistributions;
        }

        private decimal CalculateProfitDistributionForEmployee(Employee employee, List<PFSModel> pfsList, List<PTAModel> ptaList, Dictionary<string, decimal> paaDict)
        {
            decimal salary = CurrencyFormatMoneyUtils.SetDecimalFromString(employee.Salary);
            String admissionDate = employee.AdmissionDate.ToString();
            string area = employee.Area;
            string position = employee.Position;

            return salary * AppConstants.MONTHS_IN_YEAR * GetEquationResult(salary, Convert.ToDateTime(admissionDate), area, position, pfsList, ptaList, paaDict);
        }

        public decimal GetEquationResult(decimal salary, DateTime admissionDate, string area, string position, List<PFSModel> pfsList, List<PTAModel> ptaList, Dictionary<string, decimal> paaDict)
        {
            return decimal.Divide(decimal.Add(GetPTA(admissionDate, ptaList), GetPAA(area, paaDict)), GetPFS(salary, position, pfsList));
        }

        private decimal GetPAA(string area, Dictionary<string, decimal> paaDict)
        {
            return paaDict.GetValueOrDefault(area);
        }

        private decimal GetPFS(decimal salary, string position, List<PFSModel> pfsList)
        {
            if (position.Equals(AppConstants.ESTAGIARIO))
            {
                return AppConstants.PESO_UM;
            }
            else
            {
                decimal weight = 0;
                decimal salaryRatio = decimal.ToInt16(decimal.Ceiling(salary / AppConstants.MINIMUM_WAGE));
                pfsList.ForEach(pfs =>
                {
                    if (pfs.MinSalaries < salaryRatio && salaryRatio <= (pfs.MaxSalaries ?? int.MaxValue))
                    {
                        weight = pfs.Weight;
                        return;
                    }
                });
                return weight;
            }
        }

        private decimal GetPTA(DateTime admissionDate, List<PTAModel> ptaList)
        {
            int yearsInCompany = GetYearsInCompany(admissionDate);
            decimal weight = 1;
            ptaList.ForEach(pta =>
            {
                if (pta.MinYears <= yearsInCompany && yearsInCompany <= (pta.MaxYears ?? int.MaxValue))
                {
                    weight = pta.Weight;
                    return;
                }
            });
            return weight;
        }

        private int GetYearsInCompany(DateTime admissionDate)
        {
            int yearsInCompany = DateTime.Today.Year - admissionDate.Year;
            if (admissionDate > DateTime.Today.AddYears(-yearsInCompany))
            {
                yearsInCompany--;
            }
            else if (admissionDate < DateTime.Today.AddYears(-yearsInCompany))
            {
                yearsInCompany++;
            }
            return yearsInCompany;
        }
    }
}