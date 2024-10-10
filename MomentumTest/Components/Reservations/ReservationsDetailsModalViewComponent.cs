using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsDetailsModalViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke(Reservation reservation)
        {
            return View("~/Views/Shared/Components/Reservations/_ReservationDetailsModal.cshtml", reservation);
        }
    }
}