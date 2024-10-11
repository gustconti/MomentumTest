using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsEditModalViewComponent : ViewComponent
    {
        private readonly MomentumTestContext _context;

        public ReservationsEditModalViewComponent(MomentumTestContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(Reservation reservation)
        {
            if (reservation == null)
            {
                return Content(""); // Handle null case gracefully
            }

            ViewBag.Statuses = _context.Status.ToList();
            return View("~/Views/Shared/Components/Reservations/_ReservationEditModal.cshtml", reservation);
        }
    }
}
