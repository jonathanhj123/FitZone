using FitZoneApp.GUI;
using FitZoneApp.Controllers;
using FitZoneApp.Repositories;
using MongoDB.Driver;

// 1. Connect to the database
var client = new MongoClient("mongodb+srv://jona246_db_user:Mongo123@cluster0.nvbn34a.mongodb.net/");
var database = client.GetDatabase("FitzoneDB");

// 2. Create the repositories (data access layer)
var memberRepo = new MemberRepo(database);
var classRepo = new FitnessClassRepo(database);
var bookingRepo = new BookingRepo(database);

// 3. Create the controller (application layer)
var controller = new BookingController(memberRepo, classRepo, bookingRepo);

// 4. Create and start the UI (presentation layer)
var ui = new UI(controller);
ui.Run();