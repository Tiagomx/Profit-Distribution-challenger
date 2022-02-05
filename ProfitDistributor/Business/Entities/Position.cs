using Google.Cloud.Firestore;

namespace ProfitDistributor.Domain.Entities
{
    [FirestoreData]
    public class Position
    {
        public string NomeCargo { get; set; }
    }
}