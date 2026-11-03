using System;
using System.Collections.Generic;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class FitnessClassRepo : IFitnessRepo
{
    private readonly IMongoCollection<FitnessClass> classes;

    public FitnessClassRepo(IMongoDatabase database)
    {
        classes = database.GetCollection<FitnessClass>("fitnessClasses");
    }

    public List<FitnessClass> GetUpcoming(DateTime now)
    {
        return classes.Find(x => x.StartTime > now).SortBy(x=>x.StartTime).ToList();
    }

    public FitnessClass? GetById(string classId)
    {
        return classes.Find(x => x.ClassId == classId).FirstOrDefault();
    }
}
