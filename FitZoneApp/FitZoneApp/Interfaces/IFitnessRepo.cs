using FitZoneApp.Models;

namespace FitZoneApp.Interfaces;

public interface IFitnessRepo
{
    List<FitnessClass> GetUpcoming(DateTime now);
    FitnessClass? GetById(string classId);
}