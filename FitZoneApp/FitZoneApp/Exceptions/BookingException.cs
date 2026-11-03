using System;

namespace FitZoneApp.Exceptions;

// Thrown when a booking breaks a business rule (unknown member, class full, ...).
// The message is meant to be shown directly to the user.
public class BookingException : Exception
{
    public BookingException(string message) : base(message)
    {
    }
}
