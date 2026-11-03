using FitZoneApp.Models;

namespace FitZoneApp.Interfaces;

public interface IBookingRepo
{

    Booking Add(Booking b);
    bool Exists(string memberNo, string classId);
    int CountByClassId(string classId);
}