using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Interfaces;

public interface IMemberRepo
{
    Member? GetByMemberNo(string memberNo);
    
}