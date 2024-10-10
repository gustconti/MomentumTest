using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;
using System;
using System.Linq;

namespace MomentumTest.Components.Reservations
{
    public class ReservationsFilterViewComponent(MomentumTestContext context) : ViewComponent
    {
        private readonly MomentumTestContext _context = context;

        public IViewComponentResult Invoke()
        {
            var statuses = _context.Status.ToList();
            var filterModel = new ReservationsFilterViewModel
            {
                Statuses = statuses,
            };

            return View("~/Views/Shared/Components/Reservations/ReservationsFilter.cshtml", filterModel);
        }
    }
}

