using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsTableViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke(List<Reservation> reservations)
        {
            ViewBag.Status = _context.Status.ToList();
            return View("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml", reservations);
        }
    }
}