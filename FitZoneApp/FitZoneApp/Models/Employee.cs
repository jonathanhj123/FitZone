using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Models
{
    public class Employee
    {
        [BsonId]
        public  int EmployeeId { get; set; }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  Department Department { get; set; }
        public  List<Project> Myprojects { get; set; } = new List<Project>();
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employee: {Name}");
            sb.AppendLine($"  Id:         {EmployeeId}");
            sb.AppendLine($"  Email:      {Email}");
            sb.AppendLine($"  Department: {Department?.ToString() ?? "(none)"}");

            if (Myprojects == null || Myprojects.Count == 0)
            {
                sb.Append("  Projects:   (none)");
            }
            else
            {
                sb.AppendLine($"  Projects ({Myprojects.Count}):");
                foreach (var p in Myprojects)
                    sb.AppendLine($"    - {p.Name} (started {p.Start_Date:dd-MM-yyyy})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
