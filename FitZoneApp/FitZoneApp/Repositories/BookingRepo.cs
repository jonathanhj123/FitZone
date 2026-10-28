using System;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class BookingRepo
{
    private readonly IMongoCollection<Booking> bookings;

    public BookingRepo(IMongoDatabase database)
    {
        bookings = database.GetCollection<Booking>("bookings");
    }

    public int CountByClassId(string classId)
    {
        throw new NotImplementedException();
    }

    public bool Exists(string memberNo, string classId)
    {
        throw new NotImplementedException();
    }

    public Booking Add(Booking b)
    {
        throw new NotImplementedException();
    }
}
