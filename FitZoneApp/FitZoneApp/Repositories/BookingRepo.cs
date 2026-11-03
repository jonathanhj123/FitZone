using System;
using FitZoneApp.Exceptions;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class BookingRepo : IBookingRepo
{
    private readonly IMongoCollection<Booking> bookings;

    public BookingRepo(IMongoDatabase database)
    {
        bookings = database.GetCollection<Booking>("bookings");
    }

    public int CountByClassId(string classId)
    {
        return (int)bookings.CountDocuments(x => x.ClassId == classId);
    }

    public bool Exists(string memberNo, string classId)
    {
        return bookings.CountDocuments(x => x.MemberNo == memberNo && x.ClassId == classId) > 0;
    }

    public void Add(Booking b)
    {
        try
        {
            // InsertOne (not InsertOneAsync) waits for the insert, so a failure throws here
            bookings.InsertOne(b);
        }
        catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            // Same _id already exists, i.e. this member already booked this class
            throw new BookingException($"Member {b.MemberNo} has already booked class {b.ClassId}.");
        }
    }
}
