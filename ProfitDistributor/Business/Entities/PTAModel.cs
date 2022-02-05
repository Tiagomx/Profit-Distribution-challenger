using Google.Cloud.Firestore;

namespace ProfitDistributor.Domain.Entities
{
    public class PTAModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public int? MinYears { get; set; }

        [FirestoreProperty]
        public int? MaxYears { get; set; }

        [FirestoreProperty]
        public decimal Weight { get; set; }
    }
}