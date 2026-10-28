using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Controllers
{
    public class ProjectsController
    {
        private readonly ProjectsRepository _repository;
        public ProjectsController()
        {
            _repository = new ProjectsRepository();
        }

        public void CreateNewProject(string ProjectName, string Description, DateTime Start_Date)
        {
            // Opret det indlejrede Department-objekt
            Project newProject = new Project
            {
                Name = ProjectName,
                Description = Description,
                Start_Date = Start_Date
            };
            

            // Send objektet direkte videre til datalaget (Repository)
            _repository.InsertProject(newProject);
        }
    }
}
