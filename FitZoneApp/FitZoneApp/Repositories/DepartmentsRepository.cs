using MongoDB.Driver;
using MongoDBIntroductionProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Repositories
{
    public class DepartmentsRepository
    {
        private readonly IMongoCollection<Department> _departmentCollection;
        public DepartmentsRepository()
        {
            string connectionString = "mongodb+srv://adfg:1234@adfg.to8sfml.mongodb.net/";

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase database = client.GetDatabase("EventTaskManagementDB");

            _departmentCollection = database.GetCollection<Department>("departments");
        }

        public void InsertDepartment(Department department)
        {
            // Inserts the entire employee document, including the embedded department, into MongoDB.
            _departmentCollection.InsertOne(department);
        }
    }
}
