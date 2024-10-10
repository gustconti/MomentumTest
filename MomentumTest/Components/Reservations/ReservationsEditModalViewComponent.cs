using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsEditModalViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke(Reservation reservation, List<Status> statuses)
        {
            statuses = [.. _context.Status];
            var viewModel = new EditReservationViewModel(reservation, statuses);
         
            return View("~/Views/Shared/Components/Reservations/_ReservationEditModal.cshtml", viewModel);
        }
    }
}