using System;
using System.Collections.Generic;
using FitZoneApp.Exceptions;
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
        // MongoDB stores times in UTC, so compare against UTC
        return classRepo.GetUpcoming(DateTime.UtcNow);
    }

    // Checks every booking rule and throws a BookingException with a
    // user-friendly message as soon as one fails. Returns the saved booking.
    public Booking BookClass(string memberNo, string classId)
    {
        if (string.IsNullOrWhiteSpace(memberNo))
        {
            throw new BookingException("Member number cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(classId))
        {
            throw new BookingException("Class id cannot be empty.");
        }

        Member? member = memberRepo.GetByMemberNo(memberNo);
        if (member == null)
        {
            throw new BookingException($"No member with number {memberNo}.");
        }

        if (!string.Equals(member.MembershipStatus, "Active", StringComparison.OrdinalIgnoreCase))
        {
            throw new BookingException($"Membership for {member.Name} is not active ({member.MembershipStatus}).");
        }

        FitnessClass? fitnessClass = classRepo.GetById(classId);
        if (fitnessClass == null)
        {
            throw new BookingException($"No class with id {classId}.");
        }

        if (fitnessClass.StartTime <= DateTime.UtcNow)
        {
            throw new BookingException($"{fitnessClass.Title} has already started and can no longer be booked.");
        }

        if (bookingRepo.Exists(memberNo, classId))
        {
            throw new BookingException($"{member.Name} has already booked {fitnessClass.Title}.");
        }

        int bookedCount = bookingRepo.CountByClassId(classId);
        if (bookedCount >= fitnessClass.Capacity)
        {
            throw new BookingException($"{fitnessClass.Title} is full ({fitnessClass.Capacity} of {fitnessClass.Capacity} spots taken).");
        }

        Booking booking = new Booking(memberNo, classId, DateTime.UtcNow);
        bookingRepo.Add(booking);
        return booking;
    }
}
