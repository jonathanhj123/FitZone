using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MongoDBIntroductionProject.Models
{
    public class Project
    {
        [BsonId]
        public  string ProjectId { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  DateTime Start_Date { get; set; }
        
        
        public override string ToString()
        {
            var desc = string.IsNullOrWhiteSpace(Description) ? "(no description)" : Description;

            return $"Project: {Name}\n" +
                   $"  Id:          {ProjectId}\n" +
                   $"  Start date:  {Start_Date:dd-MM-yyyy}\n" +
                   $"  Description: {desc}";
        }
    }
    
    
}
