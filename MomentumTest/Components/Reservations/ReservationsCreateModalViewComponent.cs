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

            CreateReservationViewModel viewModel = new();
            var statuses = _context.Status.ToList();
            if (reservation is not null)
            {
                viewModel = new CreateReservationViewModel(reservation, statuses) { };
            }
            else
            {
                viewModel = new CreateReservationViewModel(statuses);
            }
            return View("~/Views/Shared/Components/Reservations/_ReservationCreateModal.cshtml", viewModel);
        }
    }
}