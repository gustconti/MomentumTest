using Microsoft.AspNetCore.Mvc;
using MomentumTest.Models;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Reservation> reservations)
        {
            return View("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml", reservations);
        }
    }
}