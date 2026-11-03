using System;
using System.Collections.Generic;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;
namespace FitZoneApp.Controllers;

public class BookingController
{
    private readonly IMemberRepo memberRepo;
    private readonly IFitnessRepo classRepo;
    private readonly IBookingRepo bookingRepo;

    public BookingController(IMemberRepo memberRepo, IFitnessRepo classRepo, IBookingRepo bookingRepo)
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
