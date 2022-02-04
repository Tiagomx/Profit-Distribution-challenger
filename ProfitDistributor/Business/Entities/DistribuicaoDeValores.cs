using Newtonsoft.Json;

namespace ProfitDistributor.Domain.Entities
{
    public partial class DistribuicaoDeValores
    {
        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor_da_participacao")]
        public string ValorParticipacao { get; set; }
    }
}