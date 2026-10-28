using MongoDB.Bson.Serialization.Attributes;
namespace FitZoneApp.Models;

public class Booking
{
    [BsonId]
    public string BookingId { get; set; }
    public int MemberNo { get; set; }
    public string ClassId { get; set; }
    public DateTime BookedAt { get; set; }

}