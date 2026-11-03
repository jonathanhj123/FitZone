using System;
using FitZoneApp.Interfaces;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.Repositories;

public class MemberRepo : IMemberRepo
{
    private readonly IMongoCollection<Member> members;

    public MemberRepo(IMongoDatabase database)
    {
        members = database.GetCollection<Member>("members");
    }

    public Member? GetByMemberNo(string memberNo)
    {
       return members.Find(x => x.MemberNo == memberNo).FirstOrDefault();
    }
}
