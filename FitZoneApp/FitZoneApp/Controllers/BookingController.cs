using System;
using System.Collections.Generic;
using FitZoneApp.Models;
using FitZoneApp.Repositories;

namespace FitZoneApp.Controllers;

public class BookingController
{
    private readonly MemberRepo memberRepo;
    private readonly FitnessClassRepo classRepo;
    private readonly BookingRepo bookingRepo;

    public BookingController(MemberRepo memberRepo, FitnessClassRepo classRepo, BookingRepo bookingRepo)
    {
        this.memberRepo = memberRepo;
        this.classRepo = classRepo;
        this.bookingRepo = bookingRepo;
    }

    public List<FitnessClass> GetUpcomingClasses()
    {
        throw new NotImplementedException();
    }

    public Booking BookClass(string memberNo, string classId)
    {
        throw new NotImplementedException();
    }
}
