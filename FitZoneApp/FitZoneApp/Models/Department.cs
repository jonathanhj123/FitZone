using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Models
{
    public class Department
    {
        [BsonId]
        public  string DepartmentId { get; set; }
        public  string Name { get; set; }
        
        public override string ToString() => $"{Name} ({DepartmentId})";
    }
}
