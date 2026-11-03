using FitZoneApp.Models;

namespace FitZoneApp.Interfaces;

public interface IBookingRepo
{

    void Add(Booking b);
    bool Exists(string memberNo, string classId);
    int CountByClassId(string classId);
}