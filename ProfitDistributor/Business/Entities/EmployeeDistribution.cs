using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace ProfitDistributor.Domain.Entities
{
    public partial class EmployeeDistribution
    {
        [FirestoreProperty]
        public string RegistrationId { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string DistributionAmount { get; set; }
    }
}