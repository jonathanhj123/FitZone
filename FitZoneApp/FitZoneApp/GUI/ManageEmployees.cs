using MongoDBIntroductionProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MongoDBIntroductionProject.Validation;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageEmployees
    {
        private readonly EmployeesController _controller;


        public ManageEmployees()
        {
            _controller = new EmployeesController();
        }

        public void Run()
        {
            Console.Out.WriteLine("Vil du oprette eller søge efter en medarbejder?");
            Console.Out.WriteLine("1. for at oprette.  2. For at søge, 3. For at tildele opgave til en employee");
            switch (Console.ReadLine())
            {
                case "1": Create(); break;
                case "2": Show(); break;
                case "3": Assign(); break;
            }
            
        }


        public void Create()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("    OPRET NY MEDARBEJDER (INDLEJRET)   ");
            Console.WriteLine("======================================");

            // 1. INPUT: Medarbejderdata
            Console.Write("Indtast Medarbejder ID (heltal): ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Indtast Navn: ");
            string name = Console.ReadLine();

            Console.Write("Indtast E-mail: ");
            string email = Console.ReadLine();

            // 2. INPUT: Afdelingsdata
            Console.WriteLine("\n--- AFDELINGS OPLYSNINGER ---");
            Console.Write("Afdelings ID (f.eks. DEPT_IT): ");
            string deptId = Console.ReadLine();

            Console.Write("Afdelings Navn: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("\nSender data til validering og oprettelse...");

            // GUI call the controller without project parameters
            _controller.CreateNewEmployee(employeeId, name, email,deptId, deptName );

            Console.WriteLine("\nTryk på en tast for at lukke programmet...");
            Console.ReadKey();
        }

        public void Show()
        {
            
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("    SØG EFTER MEDARBEJDER   ");
            Console.WriteLine("======================================");
            Console.Out.WriteLine("Hvad vil du bruge til at søge ");
            Console.Out.WriteLine("1. For at søge via ID, 2. For at søge via email");
            switch (Console.ReadLine())
            {
                case "1" : searchByID(); break;
                case "2" : searchByEmail(); break;
                default: Console.WriteLine("Not a valid parameter"); break;
            }
        }

        public void Assign()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("    TILDEL MEDARBEJDER TIL ENTEN PROJECT ELLER AFDELING   (INDLEJRET)   ");
            Console.WriteLine("======================================");

            Console.Out.WriteLine("1. For at tildele medarbejder til afdeling, 2. For at tildele medarbejder til project");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Out.WriteLine("Write employee id");
                    if (!int.TryParse(Console.ReadLine(), out int employeeId))
                    {
                        Console.Out.WriteLine("Not valid as an ID");
                        return;
                    }

                    Console.Out.WriteLine("Write DepartmentID");
                    if (!int.TryParse(Console.ReadLine(), out int departmentId))
                    {
                        Console.Out.WriteLine("Not valid as an ID");
                        return;
                    }
                    AssignEmployeeToDepartment(employeeId, departmentId); break;
                
                case "2":
                    Console.Out.WriteLine("Write employee id");
                    if (!int.TryParse(Console.ReadLine(), out int employeeId2))
                    {
                        Console.Out.WriteLine("Not valid as an ID");
                        return;
                    }

                    Console.Out.WriteLine("Write DepartmentID");
                    if (!int.TryParse(Console.ReadLine(), out int ProjectId))
                    {
                        Console.Out.WriteLine("Not valid as an ID");
                        return;
                    }
                    AssignEmployeeToProject(employeeId2, ProjectId); break;
            }
        }

        public void AssignEmployeeToDepartment(int employeeID, int departmentID)
        {
         
            _controller.AssignEmployeeToDepartment(employeeID, departmentID);
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
         
            _controller.AssignEmployeeToProject(employeeID, projectID);
        }

        public void searchByID()
        {
            Console.Out.WriteLine("Write the ID");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Out.WriteLine("Not valid as an ID");
                return;
            }
            var employee = _controller.searchEmployeeID(id);
            Console.Out.WriteLine(employee?.ToString() ?? "No employee found with that ID");
        }

        public void searchByEmail()
        {
            Console.Out.WriteLine("Write the email");
            string email = Console.ReadLine()?.Trim();

            if (!EmailValidator.IsValid(email))
            {
                Console.Out.WriteLine("Not a valid email");
                return;
            }
            var employee = _controller.searchEmployeeEmail(email);
            Console.Out.WriteLine(employee?.ToString() ?? "No employee found with that email");
            
            
        }
    }
}


