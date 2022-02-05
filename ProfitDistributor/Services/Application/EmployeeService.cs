using Google.Cloud.Firestore;
using Newtonsoft.Json;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Base;
using ProfitDistributor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistributor.Services.Application
{
    public class EmployeeService : FireStoreServiceBase, IEmployeeService
    {
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                Query EmployeeQuery = fireStoreDb.Collection("Employees");
                QuerySnapshot EmployeeQuerySnapshot = await EmployeeQuery.GetSnapshotAsync();
                List<Employee> listaEmployee = new List<Employee>();

                foreach (DocumentSnapshot documentSnapshot in EmployeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        Employee novoEmployee = JsonConvert.DeserializeObject<Employee>(json);
                        novoEmployee.Id = documentSnapshot.Id;
                        listaEmployee.Add(novoEmployee);
                    }
                }

                List<Employee> listaEmployeeOrdenada = listaEmployee.OrderBy(x => x.Name).ToList();
                return listaEmployeeOrdenada;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(string id)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("Employees").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Employee Employee = snapshot.ConvertTo<Employee>();
                    Employee.Id = snapshot.Id;
                    return Employee;
                }
                else
                {
                    return new Employee();
                }
            }
            catch
            {
                throw;
            }
        }

        public async void AddEmployee(Employee Employee)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("Employees");
                await colRef.AddAsync(Employee);
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateEmployee(Employee Employee)
        {
            try
            {
                DocumentReference EmployeeRef = fireStoreDb.Collection("Employees").Document(Employee.RegistrationId);
                await EmployeeRef.SetAsync(Employee, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteEmployee(string id)
        {
            try
            {
                DocumentReference EmployeeRef = fireStoreDb.Collection("Employees").Document(id);
                await EmployeeRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}