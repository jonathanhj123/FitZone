using FitZoneApp.Controllers;
using FitZoneApp.Models;

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
        throw new NotImplementedException();
    }

    public void ShowUpcomingClasses()
    {
        throw new NotImplementedException();
    }

    public void BookClass(int memberNo, string classId)
    {
        throw new NotImplementedException();
    }

    private void ShowConfirmation(Booking b)
    {
        throw new NotImplementedException();
    }

    private void ShowError(string message)
    {
        throw new NotImplementedException();
    }
}
