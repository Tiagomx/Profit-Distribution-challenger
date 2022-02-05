using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Domain.Utils;
using ProfitDistributor.Services.Interfaces;
using ProfitDistributorHelper.Services.Repositories;
using ProfitDistritor.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistributor.Application.Data
{
    public class FireStoreService : IEmployeeService
    {
        private string projectId;
        private FirestoreDb fireStoreDb;

        private const string ERROR_BALANCE = "Saldo insuficiente para distribuição";

        //private readonly IDatabaseEmployees databaseEmployees;
        private readonly IProfitCalculations profitCalculations;

        private readonly IObjectMappers objectMappers;

        public FireStoreService()
        {
            string filepath = @"C:\Users\tiago.teixeira\source\repos\ProfitDistributor\ProfitDistributor\Api\FireStoreKey\profitapp-34fab-8d750f4e4856.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "profitapp-34fab";
            fireStoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<ActionResult<Summary>> GetSummaryForProfitDistributionAsync(decimal totalAmount)
        {
            var employees = await GetEmployeesAsync();
            List<EmployeeDistribution> employeeDistributions = await profitCalculations.DistributeProfitForEmployeesAsync(employees.ToList());
            decimal totalDistributed = employeeDistributions.Sum(emp => CurrencyFormatMoneyUtils.SetDecimalFromString(emp.DistributionAmount));
            decimal distributionAmountBalance = decimal.Subtract(totalAmount, totalDistributed);

            if (IsNegative(distributionAmountBalance))
            {
                return new BadRequestObjectResult(ERROR_BALANCE);
            }

            return objectMappers.MapResultToSummary(employeeDistributions, employees.Count.ToString(), totalAmount, totalDistributed, distributionAmountBalance);
        }

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

        private bool IsNegative(decimal distributionAmountBalance)
        {
            return distributionAmountBalance.CompareTo(decimal.Zero) < decimal.Zero;
        }
    }
}