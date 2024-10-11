using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;

public class ReservationsTableViewComponent : ViewComponent
{
    private readonly MomentumTestContext _context;

    public ReservationsTableViewComponent(MomentumTestContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke(List<Reservation> reservations)
    {
        ViewBag.Statuses = _context.Status.ToList();
        return View("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml", reservations);
    }
}
