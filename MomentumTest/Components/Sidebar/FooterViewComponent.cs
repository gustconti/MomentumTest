using Microsoft.AspNetCore.Mvc;

namespace MomentumTest.Components.Sidebar
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}