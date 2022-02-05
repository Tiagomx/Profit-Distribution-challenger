using Google.Cloud.Firestore;

namespace ProfitDistributor.Domain.Entities
{
    public class PFSModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public int? MinSalaries { get; set; }

        [FirestoreProperty]
        public int? MaxSalaries { get; set; }

        [FirestoreProperty]
        public decimal Weight { get; set; }
    }
}