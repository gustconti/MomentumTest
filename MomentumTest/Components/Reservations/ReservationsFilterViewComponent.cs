using Microsoft.AspNetCore.Mvc;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Reservations/ReservationsFilter.cshtml");
        }
    }
}