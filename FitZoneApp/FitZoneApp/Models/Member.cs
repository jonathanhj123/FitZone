using MongoDB.Bson.Serialization.Attributes;

namespace FitZoneApp.Models;

public class Member
{
    [BsonId]
    public string MemberNo { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MembershipStatus { get; set; }
}
