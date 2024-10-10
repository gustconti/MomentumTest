using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsCreateModalViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke(Reservation reservation)
        {
            var statuses = _context.Status.ToList();
            var viewModel = new CreateReservationViewModel(reservation, statuses) {};
            return View("~/Views/Shared/Components/Reservations/_ReservationCreateModal.cshtml", viewModel);
        }
    }
}