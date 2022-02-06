using Google.Cloud.Firestore;
using System;
using System.IO;

namespace ProfitDistributor.Services.Base
{
    public class FireStoreServiceBase
    {
        public string projectId;
        public FirestoreDb fireStoreDb;

        public FireStoreServiceBase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filepath = Path.Combine(currentDirectory, "FireStoreKey", "profitapp-34fab-8d750f4e4856.json");

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "profitapp-34fab";
            fireStoreDb = FirestoreDb.Create(projectId);
        }
    }
}