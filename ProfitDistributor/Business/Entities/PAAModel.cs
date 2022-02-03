using Newtonsoft.Json;

namespace ProfitDistribution.Domain.Models.Profit
{
    public class PAAModel
    {
        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("peso")]
        public decimal Weight { get; set; }
    }
}
