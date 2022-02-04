using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistributor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funionario;

        public FuncionariosController(IFuncionarioService Funcionario)
        {
            _funionario = Funcionario;
        }

        [HttpGet]
        public Task<List<Funcionario>> Get()
        {
            return _funionario.GetFuncionarios();
        }

        [HttpGet("{id}")]
        public Task<Funcionario> Get(string id)
        {
            return _funionario.GetFuncionarioById(id);
        }

        [HttpPost]
        public void Post([FromBody] Funcionario Funcionario)
        {
            _funionario.AddFuncionario(Funcionario);
        }

        [HttpPut]
        public void Put([FromBody] Funcionario Funcionario)
        {
            _funionario.UpdateFuncionario(Funcionario);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _funionario.DeleteFuncionario(id);
        }

        [HttpGet("GetCargos")]
        public Task<List<Cargo>> GetCargos()
        {
            return _funionario.GetCargos();
        }
    }
}