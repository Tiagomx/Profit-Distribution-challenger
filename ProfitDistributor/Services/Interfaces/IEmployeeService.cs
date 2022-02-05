using ProfitDistributor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesAsync();

        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);

        public Task<Employee> GetEmployeeById(string id);

        public void DeleteEmployee(string id);
    }
}