using System;
using FitZoneApp.Controllers;
using FitZoneApp.Exceptions;
using FitZoneApp.Models;
using MongoDB.Driver;

namespace FitZoneApp.GUI;

public class UI
{
    private readonly BookingController controller;

    public UI(BookingController controller)
    {
        this.controller = controller;
    }

    // Entry point called from Program.cs (not in the class diagram)
    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  ╔══════════════════════════════════════╗");
        Console.WriteLine("  ║          🏋️  F I T Z O N E           ║");
        Console.WriteLine("  ║      Fitness class booking system    ║");
        Console.WriteLine("  ╚══════════════════════════════════════╝");
        Console.ResetColor();

        var running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("  ┌─────────────── MAIN MENU ────────────┐");
            Console.WriteLine("  │  1 │ 📅  View upcoming classes       │");
            Console.WriteLine("  │  2 │ ✅  Book a class                │");
            Console.WriteLine("  │  0 │ 🚪  Exit                        │");
            Console.WriteLine("  └──────────────────────────────────────┘");
            Console.Write("  Choose an option » ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("  ── Upcoming classes ──");
                    ShowUpcomingClasses();
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("  ── Book a class ──");
                    Console.Write("  Member number » ");
                    var memberNo = Console.ReadLine()?.Trim() ?? "";
                    if (memberNo.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  ✖ Member number cannot be empty.");
                        Console.ResetColor();
                        break;
                    }
                    Console.Write("  Class id      » ");
                    var classId = Console.ReadLine()?.Trim() ?? "";
                    BookClass(memberNo, classId);
                    break;

                case "0":
                case null: // input closed (Ctrl+Z / Ctrl+D), treat as exit
                    running = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("  👋 Thanks for using FitZone. See you at the gym!");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ⚠ Unknown option, please pick 1, 2 or 0.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    public void ShowUpcomingClasses()
    {
        List<FitnessClass> classes;
        try
        {
            classes = controller.GetUpcomingClasses();
        }
        catch (Exception ex) when (ex is MongoException || ex is TimeoutException)
        {
            ShowError("Could not reach the database. Please try again later.");
            return;
        }

        if (classes.Count == 0)
        {
            Console.WriteLine("  No upcoming classes.");
            return;
        }

        foreach (FitnessClass c in classes)
        {
            Console.WriteLine($"  [{c.ClassId}] {c.Title} -{c.StartTime:yyyy-MM-dd HH:mm} (capacity {c.Capacity})");
        }
    }

    public void BookClass(string memberNo, string classId)
    {
        try
        {
            Booking booking = controller.BookClass(memberNo, classId);
            ShowConfirmation(booking);
        }
        catch (BookingException ex)
        {
            // A booking rule was broken: the message is written for the user
            ShowError(ex.Message);
        }
        catch (Exception ex) when (ex is MongoException || ex is TimeoutException)
        {
            // Database is down or unreachable
            ShowError("Could not reach the database. Please try again later.");
        }
    }

    private void ShowConfirmation(Booking b)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  ✔ Booking confirmed: member {b.MemberNo} is booked on class {b.ClassId} (booking id {b.BookingId}).");
        Console.ResetColor();
    }

    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  ✖ {message}");
        Console.ResetColor();
    }
}
