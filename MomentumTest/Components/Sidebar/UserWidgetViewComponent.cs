using Microsoft.AspNetCore.Mvc;
using MomentumTest.Data;
using MomentumTest.Models;
using System.Collections.Generic;

namespace MomentumTest.Components.Sidebar
{
    public class UserWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var user = MockUserData.GetUserData();
            return View(user);
        }
    }
}