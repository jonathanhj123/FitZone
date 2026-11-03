using System;
using System.Collections.Generic;
using System.Linq;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;

namespace FitZoneApp.Repositories.InMemory;

// Keeps fitness classes in a list in memory instead of MongoDB.
// Start times are relative to today, so there are always upcoming classes to book.
public class InMemoryFitnessClassRepo : IFitnessRepo
{
    private readonly List<FitnessClass> classes;

    public InMemoryFitnessClassRepo()
    {
        DateTime today = DateTime.UtcNow.Date;

        classes = new List<FitnessClass>
        {
            // Already started: useful for testing the "class has already started" rule
            new FitnessClass { ClassId = "C201", Title = "Spinning", Instructor = "Lars",  Room = "Studio 1", StartTime = today.AddDays(-1).AddHours(8),  DurationMinutes = 45, Capacity = 12 },
            // Only 2 spots: useful for testing the "class is full" rule
            new FitnessClass { ClassId = "C202", Title = "Yoga",     Instructor = "Emma",  Room = "Studio 2", StartTime = today.AddDays(1).AddHours(7),   DurationMinutes = 60, Capacity = 2 },
            new FitnessClass { ClassId = "C203", Title = "Crossfit", Instructor = "Jonas", Room = "Hall",     StartTime = today.AddDays(2).AddHours(17),  DurationMinutes = 50, Capacity = 10 },
            new FitnessClass { ClassId = "C204", Title = "Pilates",  Instructor = "Signe", Room = "Studio 2", StartTime = today.AddDays(3).AddHours(9),   DurationMinutes = 55, Capacity = 8 },
            new FitnessClass { ClassId = "C205", Title = "Zumba",    Instructor = "Maria", Room = "Studio 1", StartTime = today.AddDays(5).AddHours(18),  DurationMinutes = 45, Capacity = 15 },
        };
    }

    public List<FitnessClass> GetUpcoming(DateTime now)
    {
        return classes.Where(x => x.StartTime > now).OrderBy(x => x.StartTime).ToList();
    }

    public FitnessClass? GetById(string classId)
    {
        return classes.FirstOrDefault(x => x.ClassId == classId);
    }
}
