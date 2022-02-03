using Google.Cloud.Firestore;

namespace ProfitDistributor.Domain.Entities
{
    [FirestoreData]
    public class Cargo
    {
        public string NomeCargo { get; set; }
    }
}