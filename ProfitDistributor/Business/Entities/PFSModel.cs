using Newtonsoft.Json;

namespace ProfitDistribution.Domain.Models.Profit
{
    public class PFSModel
    {
        [JsonProperty("minSalarios")]
        public int? MinSalaries { get; set; }

        [JsonProperty("maxSalarios")]
        public int? MaxSalaries { get; set; }

        [JsonProperty("peso")]
        public decimal Weight { get; set; }

    }
}
