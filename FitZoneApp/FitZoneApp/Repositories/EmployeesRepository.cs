using MongoDB.Driver;
using MongoDBIntroductionProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Repositories
{
    public class EmployeesRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeesRepository()
        {
            string connectionString = "mongodb+srv://adfg:1234@adfg.to8sfml.mongodb.net/    ";

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase database = client.GetDatabase("EventTaskManagementDB");

            _employeeCollection = database.GetCollection<Employee>("employees");
        }

        public void InsertEmployee(Employee employee)
        {
            // Inserts the entire employee document, including the embedded department, into MongoDB.
            _employeeCollection.InsertOne(employee);
            
            
        }

        public Employee getEmployeeByEmail(string email)
        {
            var filter = Builders<Employee>.Filter.Eq("Email", email);

            return _employeeCollection.Find(filter)
                .FirstOrDefault();
        }
        public Employee getEmployeeByID(int id)
        {
            var filter = Builders<Employee>.Filter.Eq("_id", id);

            return _employeeCollection.Find(filter)
                .FirstOrDefault();
        }
    }
}
