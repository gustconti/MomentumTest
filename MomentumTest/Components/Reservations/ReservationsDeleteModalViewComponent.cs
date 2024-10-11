using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsDeleteModalViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke(Reservation reservation)
        {
            return View("~/Views/Shared/Components/Reservations/_ReservationDeleteModal.cshtml", reservation);
        }
    }
}