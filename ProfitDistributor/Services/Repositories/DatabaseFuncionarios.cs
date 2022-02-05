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

        public async Task<List<Employee>> FetchAllFuncionariosAsync()
        {
            List<Employee> funcionarios = new List<Employee>();

            var httpClient = new HttpClient();

            using (HttpResponseMessage response = await httpClient.GetAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES))
            {
                string func = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Employee>>(func);
            }
        }

        public async Task<HttpResponseMessage> PostToFireBaseEmployeesAsync(Employee funcionario)
        {
            var firebase = new FirebaseClient(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(AppConstants.BASE_URL_DB_FIREBASE + ENDPOINT_EMPLOYEES, new StringContent(JsonConvert.SerializeObject(funcionario)));

            return response;
        }
    }
}