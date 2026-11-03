using System.Collections.Generic;
using System.Linq;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;

namespace FitZoneApp.Repositories.InMemory;

// Keeps members in a list in memory instead of MongoDB.
// Data is reset every time the app starts.
public class InMemoryMemberRepo : IMemberRepo
{
    private readonly List<Member> members = new List<Member>
    {
        new Member { MemberNo = "M1001", Name = "Anna Jensen",   Email = "anna.jensen@mail.dk",   MembershipStatus = "Active" },
        new Member { MemberNo = "M1002", Name = "Mikkel Hansen", Email = "mikkel.hansen@mail.dk", MembershipStatus = "Active" },
        new Member { MemberNo = "M1003", Name = "Sofie Nielsen", Email = "sofie.nielsen@mail.dk", MembershipStatus = "Inactive" },
        new Member { MemberNo = "M1004", Name = "Peter Larsen",  Email = "peter.larsen@mail.dk",  MembershipStatus = "Active" },
    };

    public Member? GetByMemberNo(string memberNo)
    {
        return members.FirstOrDefault(x => x.MemberNo == memberNo);
    }
}
