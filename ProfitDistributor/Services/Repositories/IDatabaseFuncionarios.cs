using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase.Database;
using ProfitDistributor.Domain.Entities;

namespace ProfitDistributorHelper.Services.Repositories
{
    // This interface could be implemented for firebase or Redis Cloud or other database provider.
    public interface IDatabaseFuncionarios
    {
        Task<List<Employee>> FetchAllFuncionariosAsync();

        Task<HttpResponseMessage> PostToFireBaseEmployeesAsync(Employee funcionario);
    }
}