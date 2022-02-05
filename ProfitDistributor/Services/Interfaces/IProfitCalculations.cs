using ProfitDistributor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IProfitCalculations
    {
        Task<List<EmployeeDistribution>> DistributeProfitForEmployeesAsync(List<Employee> funcionarios);
    }
}