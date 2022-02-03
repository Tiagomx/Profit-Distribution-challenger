using Newtonsoft.Json;

namespace ProfitDistributor.Domain.Entities
{
    public partial class EmployeeDistribution
    {
        [JsonProperty("matricula")]
        public string RegistrationId { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("valor_da_participacao")]
        public string DistributionAmount { get; set; }
    }
}