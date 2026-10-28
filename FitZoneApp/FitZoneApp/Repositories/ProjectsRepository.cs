using MongoDB.Driver;
using MongoDBIntroductionProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Repositories
{
    public class ProjectsRepository
    {
        private readonly IMongoCollection<Project> _projectsCollection;
        public ProjectsRepository()
        {
            string connectionString = "mongodb+srv://adfg:1234@adfg.to8sfml.mongodb.net/";

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase database = client.GetDatabase("EventTaskManagementDB");

            _projectsCollection = database.GetCollection<Project>("projects");
        }

        public void InsertProject(Project project)
        {
            // Inserts the entire employee document, including the embedded department, into MongoDB.
            _projectsCollection.InsertOne(project);
        }
    }
}
