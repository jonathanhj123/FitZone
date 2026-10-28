using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Controllers
{
    public class DepartmentsController
    {
        private readonly DepartmentsRepository _repository;
        public DepartmentsController()
        {
            _repository = new DepartmentsRepository();
        }

        public void CreateNewDepartment(string deptId, string deptName)
        {
            // Opret det indlejrede Department-objekt
            Department newDepartment = new Department
            {
                DepartmentId = deptId,
                Name = deptName
            };

            // Send objektet direkte videre til datalaget (Repository)
            _repository.InsertDepartment(newDepartment);
        }
    }
}
