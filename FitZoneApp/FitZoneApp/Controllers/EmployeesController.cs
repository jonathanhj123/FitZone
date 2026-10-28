using MongoDBIntroductionProject.Models;
using MongoDBIntroductionProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Controllers
{
    public class EmployeesController
    {
        private readonly EmployeesRepository _repository;
        public EmployeesController()
        {
            _repository = new EmployeesRepository();
        }

        public void CreateNewEmployee(int employeeId, string name, string email, string deptId, string deptName)
        {
            // Opret det indlejrede Department-objekt
            Department embeddedDept = new Department
            {
                DepartmentId = deptId,
                Name = deptName
            };

            // Opret hoveddokumentet (Employee) og tilknyt den indlejrede afdeling
            Employee newEmployee =  new Employee
            {
                EmployeeId = employeeId,
                Name = name,
                Email = email,
                Department = embeddedDept
            };

            // Send objektet direkte videre til datalaget (Repository)
            _repository.InsertEmployee(newEmployee);
        }

        public Employee searchEmployeeID(int id)
        {
            return _repository.getEmployeeByID(id);
        }
        public Employee searchEmployeeEmail(string email)
        {
         
         return _repository.getEmployeeByEmail(email);
        }

        public void AssignEmployeeToDepartment(int employeeID, int projectID)
        {
            Employee newEmployee = searchEmployeeID(employeeID);
            
        }

        public void AssignEmployeeToProject(int employee, int projectID)
        {
            
        }
    }
}
