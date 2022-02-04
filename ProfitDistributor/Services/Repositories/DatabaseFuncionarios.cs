using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Firebase.Database;
using Firebase.Database.Query;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;

namespace ProfitDistributorHelper.Services.Repositories
{
    public class DatabaseFuncionarios : IDatabaseFuncionarios
    {
        private const string ENDPOINT_EMPLOYEES = "/employees.json";

        public async Task<List<Funcionario>> FetchAllFuncionariosAsync()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            var httpClient = new HttpClient();

            using (HttpResponseMessage response = await httpClient.GetAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES))
            {
                string func = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Funcionario>>(func); ;
            }
        }

        public async Task<HttpResponseMessage> PostToFireBaseEmployeesAsync(Funcionario funcionario)
        {
            var firebase = new FirebaseClient(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES, new StringContent(JsonConvert.SerializeObject(funcionario)));

            return response;
        }
    }
}