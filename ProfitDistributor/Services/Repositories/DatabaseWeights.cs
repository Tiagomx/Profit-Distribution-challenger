using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Base;
using ProfitDistributor.Services.Interfaces;

namespace ProfitDistributor.Services.Repositories
{
    public class DatabaseWeights : FireStoreServiceBase, IDatabaseWeights
    {
        public async Task<List<PTAModel>> GetAllPTAAsync()
        {
            try
            {
                Query PTAQuery = fireStoreDb.Collection("PTA");
                QuerySnapshot PTAQuerySnapshot = await PTAQuery.GetSnapshotAsync();
                List<PTAModel> listPTA = new List<PTAModel>();

                foreach (DocumentSnapshot documentSnapshot in PTAQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        PTAModel novoPTA = JsonConvert.DeserializeObject<PTAModel>(json);
                        novoPTA.Id = documentSnapshot.Id;
                        listPTA.Add(novoPTA);
                    }
                }

                List<PTAModel> listPTAOrdered = listPTA.OrderBy(x => x.MinYears).ToList();
                return listPTAOrdered;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }

        public async Task<List<PFSModel>> GetAllPFSAsync()
        {
            try
            {
                Query PFSQuery = fireStoreDb.Collection("PFS");
                QuerySnapshot PFSQuerySnapshot = await PFSQuery.GetSnapshotAsync();
                List<PFSModel> listPFS = new List<PFSModel>();

                foreach (DocumentSnapshot documentSnapshot in PFSQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        PFSModel novoPFS = JsonConvert.DeserializeObject<PFSModel>(json);
                        novoPFS.Id = documentSnapshot.Id;
                        listPFS.Add(novoPFS);
                    }
                }

                List<PFSModel> listPFSOrdered = listPFS.OrderBy(x => x.MinSalaries).ToList();
                return listPFSOrdered;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }

        public async Task<List<PAAModel>> GetAllPAAAsync()
        {
            try
            {
                Query PAAQuery = fireStoreDb.Collection("PAA");
                QuerySnapshot PAAQuerySnapshot = await PAAQuery.GetSnapshotAsync();
                List<PAAModel> listPAA = new List<PAAModel>();

                foreach (DocumentSnapshot documentSnapshot in PAAQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        PAAModel novoPAA = JsonConvert.DeserializeObject<PAAModel>(json);
                        novoPAA.Id = documentSnapshot.Id;
                        listPAA.Add(novoPAA);
                    }
                }

                List<PAAModel> listPAAOrdered = listPAA.OrderBy(x => x.Area).ToList();
                return listPAAOrdered;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }
    }
}