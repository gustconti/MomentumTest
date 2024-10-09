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
        private readonly MomentumTestContext _context = context; // Inject your DbContext or service

        public IViewComponentResult Invoke()
        {
            // Fetching all statuses and guests for dropdown options.
            var statuses = _context.Status.ToList();
            // Create the view model with necessary data for filtering
            var filterModel = new ReservationsFilterModelDTO
            {
                Statuses = statuses,
            };

            return View("~/Views/Shared/Components/Reservations/ReservationsFilter.cshtml", filterModel);
        }

        [HttpPost]
        public IViewComponentResult Filter(ReservationsFilterModelDTO filter)
        {
            var query = _context.Reservation.AsQueryable();

            if (filter.StartDate != null)
            {
                query = query.Where(r => r.StartDate >= filter.StartDate);
            }
            if (filter.EndDate != null)
            {
                query = query.Where(r => r.EndDate <= filter.EndDate);
            }
            if (filter.StatusId > 0)
            {
                query = query.Where(r => r.StatusId == filter.StatusId);
            }
            if (!string.IsNullOrEmpty(filter.GuestName))
            {
                query = query.Where(r => r.MainGuest.Name != null && r.MainGuest.Name.Contains(filter.GuestName));
            }

            var filteredReservations = query.ToList();

            return View("ReservationsTable", filteredReservations);
        }
    }
}

