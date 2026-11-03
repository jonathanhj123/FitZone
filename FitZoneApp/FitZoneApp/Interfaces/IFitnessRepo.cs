using FitZoneApp.Models;

namespace FitZoneApp.Interfaces;

public interface IFitnessRepo
{
    List<FitnessClass> GetUpcomming(DateTime now);
    FitnessClass? GetById(string classId);
}