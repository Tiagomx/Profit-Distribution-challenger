using Google.Cloud.Firestore;

namespace ProfitDistributorTool.Domain.Entities
{
    [FirestoreData]
    public class Cargo
    {
        public string NomeCargo { get; set; }
    }
}