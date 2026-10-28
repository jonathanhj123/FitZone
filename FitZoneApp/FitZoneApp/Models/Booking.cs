using MongoDB.Bson.Serialization.Attributes;
namespace FitZoneApp.Models;

public class Booking
{
    [BsonId]
    public string BookingId { get; set; }
    public int MemberNo { get; set; }
    public string ClassId { get; set; }
    public DateTime BookingTime { get; set; }

    // Parameterless constructor for the MongoDB deserializer
    public Booking() { }

    public Booking(int memberNo, string classId, DateTime bookingTime)
    {
        throw new NotImplementedException();
    }
}
