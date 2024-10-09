using Microsoft.AspNetCore.Mvc;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml");
        }
    }
}