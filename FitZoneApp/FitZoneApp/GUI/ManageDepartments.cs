using MongoDBIntroductionProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageDepartments
    {
        private readonly DepartmentsController _controller;

       
        public ManageDepartments()
        {
            _controller = new DepartmentsController();
        }
        
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("    OPRET NY AFDELING (INDLEJRET)   ");
            Console.WriteLine("======================================");
            
            // 2. INPUT: Afdelingsdata
            Console.WriteLine("\n--- AFDELINGS OPLYSNINGER ---");
            Console.Write("Afdelings ID (f.eks. DEPT_IT): ");
            string deptId = Console.ReadLine();

            Console.Write("Afdelings Navn: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("\nSender data til validering og oprettelse...");

            // GUI call the controller without project parameters
            _controller.CreateNewDepartment(deptId, deptName );

            Console.WriteLine("\nTryk på en tast for at lukke programmet...");
            Console.ReadKey();
        }
    }
}


