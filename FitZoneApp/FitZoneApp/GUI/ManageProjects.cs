using MongoDBIntroductionProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.GUI
{
    internal class ManageProjects
    {
        private readonly ProjectsController _controller;

       
        public ManageProjects()
        {
            _controller = new ProjectsController();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("    OPRET ET NYT PROJECT (INDLEJRET)   ");
            Console.WriteLine("======================================");

            // INPUT: Projectdata
            Console.WriteLine("\n--- Project Navn ---");
            string projectNavn = Console.ReadLine();

            Console.Write("Project Beskrivelse: ");
            string projectBeskrivelse = Console.ReadLine();

            Console.WriteLine("\nSender data til validering og oprettelse...");

            // GUI call the controller without project parameters
            _controller.CreateNewProject(projectNavn, projectBeskrivelse, DateTime.Now );

            Console.WriteLine("\nTryk på en tast for at lukke programmet...");
            Console.ReadKey();
        }
    }
}


