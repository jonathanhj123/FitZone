using System;
using System.Collections.Generic;
using System.Linq;
using FitZoneApp.Exceptions;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;

namespace FitZoneApp.Repositories.InMemory;

// Keeps bookings in a list in memory instead of MongoDB.
// Bookings made while the app runs are lost when it closes.
public class InMemoryBookingRepo : IBookingRepo
{
    private readonly List<Booking> bookings = new List<Booking>
    {
        // Takes 1 of the 2 spots on Yoga (C202)
        new Booking("M1001", "C202", DateTime.UtcNow.AddDays(-1)),
    };

    public int CountByClassId(string classId)
    {
        return bookings.Count(x => x.ClassId == classId);
    }

    public bool Exists(string memberNo, string classId)
    {
        return bookings.Any(x => x.MemberNo == memberNo && x.ClassId == classId);
    }

    public void Add(Booking b)
    {
        // Same rule as MongoDB's unique _id: one booking per member per class
        if (bookings.Any(x => x.BookingId == b.BookingId))
        {
            throw new BookingException($"Member {b.MemberNo} has already booked class {b.ClassId}.");
        }

        bookings.Add(b);
    }
}
