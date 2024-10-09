using Microsoft.AspNetCore.Mvc;

namespace MomentumTest.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}