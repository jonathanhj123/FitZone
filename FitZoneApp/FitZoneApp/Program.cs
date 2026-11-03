using FitZoneApp.GUI;
using FitZoneApp.Controllers;
using FitZoneApp.Interfaces;
using FitZoneApp.Repositories;
using FitZoneApp.Repositories.InMemory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

// 1. Read settings from appsettings.json (copied next to the .exe on build)
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

// "Mongo" or "InMemory"
string provider = config["Database:Provider"] ?? "Mongo";

// 2. Create the repositories (data access layer).
//    The variables are interface types, so the rest of the app doesn't care which ones we pick.
IMemberRepo memberRepo;
IFitnessRepo classRepo;
IBookingRepo bookingRepo;

if (provider.Equals("InMemory", StringComparison.OrdinalIgnoreCase))
{
    memberRepo = new InMemoryMemberRepo();
    classRepo = new InMemoryFitnessClassRepo();
    bookingRepo = new InMemoryBookingRepo();
}
else if (provider.Equals("Mongo", StringComparison.OrdinalIgnoreCase))
{
    string connectionString = config.GetConnectionString("FitzoneDB")
        ?? throw new InvalidOperationException("Connection string 'FitzoneDB' is missing in appsettings.json.");
    string databaseName = config["Database:Name"]
        ?? throw new InvalidOperationException("'Database:Name' is missing in appsettings.json.");

    MongoClient client = new MongoClient(connectionString);
    IMongoDatabase database = client.GetDatabase(databaseName);

    memberRepo = new MemberRepo(database);
    classRepo = new FitnessClassRepo(database);
    bookingRepo = new BookingRepo(database);
}
else
{
    throw new InvalidOperationException($"Unknown Database:Provider '{provider}' in appsettings.json. Use \"Mongo\" or \"InMemory\".");
}

// 3. Create the controller (application layer)
BookingController controller = new BookingController(memberRepo, classRepo, bookingRepo);

// 4. Create and start the UI (presentation layer)
UI ui = new UI(controller);
ui.Run();
