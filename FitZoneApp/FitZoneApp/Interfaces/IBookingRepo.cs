using FitZoneApp.Models;

namespace FitZoneApp.Interfaces;

public interface IBookingRepo
{
    Member? GetByMemberNo(string memberNo);
}