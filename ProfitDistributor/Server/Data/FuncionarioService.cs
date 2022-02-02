using Google.Cloud.Firestore;
using Newtonsoft.Json;
using ProfitDistributor.Domain.Intefaces;
using ProfitDistributorTool.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistributor.Server.Data
{
    public class FuncionarioService : IFuncionarioService
    {
        private string projectId;
        private FirestoreDb fireStoreDb;

        public FuncionarioService()
        {
            string filepath = @"C:\Users\tiago.teixeira\Downloads\Blazor_Firestorer\Blazor_Firestorer\Server\FirestoreApiKey\blazorcrudfirestore-1565827c5156.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "blazorcrudfirestore";
            fireStoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Funcionario>> GetFuncionarios()
        {
            try
            {
                Query FuncionarioQuery = fireStoreDb.Collection("Funcionarios");
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
                DocumentReference docRef = fireStoreDb.Collection("Funcionarios").Document(id);
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
                CollectionReference colRef = fireStoreDb.Collection("Funcionarios");
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
                DocumentReference FuncionarioRef = fireStoreDb.Collection("Funcionarios").Document(Funcionario.Id);
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
                DocumentReference FuncionarioRef = fireStoreDb.Collection("Funcionarios").Document(id);
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
                Query CargosQuery = fireStoreDb.Collection("Cargos");
                QuerySnapshot CargosQuerySnapshot = await CargosQuery.GetSnapshotAsync();
                List<Cargo> listaCargos = new List<Cargo>();

                foreach (DocumentSnapshot documentSnapshot in CargosQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        Cargo novaCargo = JsonConvert.DeserializeObject<Cargo>(json);
                        listaCargos.Add(novaCargo);
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