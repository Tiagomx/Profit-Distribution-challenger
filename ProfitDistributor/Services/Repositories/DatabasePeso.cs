using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProfitDistribution.Domain.Models.Profit;
using ProfitDistributor.Domain.Utils;

namespace ProfitDistributorHelper.Services.Repositories
{
    public class DatabasePeso : IDatabasePeso
    {
        private const string ENDPOINT_PAA = "/paa.json";
        private const string ENDPOINT_PTA = "/pta.json";
        private const string ENDPOINT_PFS = "/pfs.json";
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<List<PTAModel>> FetchAllPTAAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PTA, null));
            string pta = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PTAModel>>(pta);
        }

        public async Task<List<PFSModel>> FetchAllPFSAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PFS, null));
            string pfs = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PFSModel>>(pfs);
        }

        public async Task<List<PAAModel>> FetchAllPAAAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(GetFirebaseEndpoint(ENDPOINT_PAA, null));
            string paa = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PAAModel>>(paa);
        }

        private string GetFirebaseEndpoint(string endpoint, string query)
        {
            if (query == null)
            {
                return AppConstants.BASE_URL_DB_FIREBASE + endpoint;
            }
            return AppConstants.BASE_URL_DB_FIREBASE + endpoint + query;
        }
    }
}