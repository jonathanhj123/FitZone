using System;
using MongoDB.Bson.Serialization.Attributes;

namespace FitZoneApp.Models;

public class FitnessClass
{
    [BsonId]
    public string ClassId { get; set; }
    public string Title { get; set; }
    public string Instructor { get; set; }
    public string Room { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationMinutes { get; set; }
    public int Capacity { get; set; }
}
