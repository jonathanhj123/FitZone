using System;
using System.Collections.Generic;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class FitnessClassRepo
{
    private readonly IMongoCollection<FitnessClass> classes;

    public FitnessClassRepo(IMongoDatabase database)
    {
        classes = database.GetCollection<FitnessClass>("fitnessClasses");
    }

    public List<FitnessClass> GetUpcoming(DateTime now)
    {
        throw new NotImplementedException();
    }

    public FitnessClass? GetById(string classId)
    {
        throw new NotImplementedException();
    }
}
