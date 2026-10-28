using System;
using MongoDB.Bson.Serialization.Attributes;
namespace FitZoneApp.Models;

public class Booking
{
    [BsonId]
    public string BookingId { get; set; }
    public string MemberNo { get; set; }
    public string ClassId { get; set; }
    public DateTime BookingTime { get; set; }

    // Parameterless constructor for the MongoDB deserializer
    public Booking() { }

    public Booking(string memberNo, string classId, DateTime bookingTime)
    {
        throw new NotImplementedException();
    }
}
