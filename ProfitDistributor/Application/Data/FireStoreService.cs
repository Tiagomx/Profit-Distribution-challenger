using Google.Cloud.Firestore;
using Newtonsoft.Json;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Intefaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistributor.Application.Data
{
    public class FireStoreService : IFuncionarioService
    {
        private string projectId;
        private FirestoreDb fireStoreDb;

        public FireStoreService()
        {
            string filepath = @"C:\Users\tiago.teixeira\source\repos\ProfitDistributor\ProfitDistributor\Application\FireStoreKey\profitapp-34fab-8d750f4e4856.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "profitapp-34fab";
            fireStoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Funcionario>> GetFuncionarios()
        {
            try
            {
                Query FuncionarioQuery = fireStoreDb.Collection("funcionarios");
                QuerySnapshot FuncionarioQuerySnapshot = await FuncionarioQuery.GetSnapshotAsync();
                List<Funcionario> listaFuncionario = new List<Funcionario>();

                foreach (DocumentSnapshot documentSnapshot in FuncionarioQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        Funcionario novoFuncionario = JsonConvert.DeserializeObject<Funcionario>(json);
                        novoFuncionario.Id = documentSnapshot.Id;
                        listaFuncionario.Add(novoFuncionario);
                    }
                }

                List<Funcionario> listaFuncionarioOrdenada = listaFuncionario.OrderBy(x => x.Nome).ToList();
                return listaFuncionarioOrdenada;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }

        public async Task<Funcionario> GetFuncionarioById(string id)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("funcionarios").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Funcionario Funcionario = snapshot.ConvertTo<Funcionario>();
                    Funcionario.Id = snapshot.Id;
                    return Funcionario;
                }
                else
                {
                    return new Funcionario();
                }
            }
            catch
            {
                throw;
            }
        }

        public async void AddFuncionario(Funcionario Funcionario)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("funcionarios");
                await colRef.AddAsync(Funcionario);
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateFuncionario(Funcionario Funcionario)
        {
            try
            {
                DocumentReference FuncionarioRef = fireStoreDb.Collection("funcionarios").Document(Funcionario.Id);
                await FuncionarioRef.SetAsync(Funcionario, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteFuncionario(string id)
        {
            try
            {
                DocumentReference FuncionarioRef = fireStoreDb.Collection("funcionarios").Document(id);
                await FuncionarioRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Cargo>> GetCargos()
        {
            try
            {
                Query CargosQuery = fireStoreDb.Collection("cargo");
                QuerySnapshot CargosQuerySnapshot = await CargosQuery.GetSnapshotAsync();
                List<Cargo> listaCargos = new List<Cargo>();

                foreach (DocumentSnapshot documentSnapshot in CargosQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> cargo = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(cargo);
                        Cargo novoCargo = JsonConvert.DeserializeObject<Cargo>(json);
                        listaCargos.Add(novoCargo);
                    }
                }
                return listaCargos;
            }
            catch
            {
                throw;
            }
        }
    }
}