using System;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class MemberRepo
{
    private readonly IMongoCollection<Member> members;

    public MemberRepo(IMongoDatabase database)
    {
        members = database.GetCollection<Member>("members");
    }

    public Member? GetByMemberNo(int memberNo)
    {
        throw new NotImplementedException();
    }
}
