using Google.Cloud.Firestore;
using System;

namespace ProfitDistributor.Domain.Entities
{
    [FirestoreData]
    public class Funcionario
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string Matricula { get; set; }

        [FirestoreProperty]
        public string Nome { get; set; }

        [FirestoreProperty]
        public string Area { get; set; }

        [FirestoreProperty]
        public string Cargo { get; set; }

        [FirestoreProperty]
        public string SalarioBruto { get; set; }

        [FirestoreProperty]
        public DateTime DataAdmissao { get; set; }
    }
}