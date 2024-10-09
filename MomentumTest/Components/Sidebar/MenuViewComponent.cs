using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;

namespace MomentumTest.Components.Sidebar
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = MockMenuData.GetMenuItems();
            return View("~/Views/Shared/Components/Sidebar/Menu.cshtml", menuItems);
        }
    }
}