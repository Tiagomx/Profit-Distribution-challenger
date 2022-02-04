using ProfitDistributor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistributor.Services.Interfaces
{
    public interface IFuncionarioService
    {
        public Task<List<Funcionario>> GetFuncionarios();

        public void AddFuncionario(Funcionario employee);

        public void UpdateFuncionario(Funcionario employee);

        public Task<Funcionario> GetFuncionarioById(string id);

        public void DeleteFuncionario(string id);

        public Task<List<Cargo>> GetCargos();
    }
}