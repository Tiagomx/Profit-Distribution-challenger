using Google.Cloud.Firestore;
using System;

namespace ProfitDistributor.Domain.Entities
{
    [FirestoreData]
    public class Employee
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string RegistrationId { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Area { get; set; }

        [FirestoreProperty]
        public string Position { get; set; }

        [FirestoreProperty]
        public string Salary { get; set; }

        [FirestoreProperty]
        public string AdmissionDate { get; set; }
    }
}