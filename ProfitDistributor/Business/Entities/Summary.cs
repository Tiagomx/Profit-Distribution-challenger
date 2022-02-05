using System.Collections.Generic;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace ProfitDistributor.Domain.Entities
{
    public partial class Summary
    {
        [FirestoreProperty]
        public List<EmployeeDistribution> Distributions { get; set; }

        [FirestoreProperty]
        public string TotalEmployees { get; set; }

        [FirestoreProperty]
        public string DistributedAmount { get; set; }

        [FirestoreProperty]
        public string AvailableAmount { get; set; }

        [FirestoreProperty]
        public string DistributionAmountBalance { get; set; }
    }
}