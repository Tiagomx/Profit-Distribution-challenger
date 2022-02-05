using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace ProfitDistributor.Domain.Entities
{
    public class PAAModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string Area { get; set; }

        [FirestoreProperty]
        public decimal Weight { get; set; }
    }
}