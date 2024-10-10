using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MomentumTest.Data;
using MomentumTest.Models;
using MomentumTest.Models.ViewModels;

namespace MomentumTest.Controllers;

public class HomeController(ILogger<HomeController> logger, MomentumTestContext context) : Controller
{
    private readonly MomentumTestContext _context = context;

    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Filter(ReservationsFilterViewModel filter, int pageNumber = 1, int itemsPerPage = 8)
    {
        var query = _context.Reservation
            .Include(r => r.Status)
            .Include(r => r.MainGuest)
            .AsQueryable();

        if (filter.ReservationId.HasValue && filter.ReservationId.Value > 0)
        {
            query = query.Where(r => r.Id == filter.ReservationId.Value);
        }

        if (filter.StartDate.HasValue)
        {
            query = query.Where(r => r.StartDate >= filter.StartDate.Value);
        }

        if (filter.EndDate.HasValue)
        {
            query = query.Where(r => r.EndDate <= filter.EndDate.Value);
        }

        if (filter.StatusId > 0)
        {
            query = query.Where(r => r.StatusId == filter.StatusId);
        }

        if (!string.IsNullOrEmpty(filter.GuestName))
        {
            query = query.Where(r => r.MainGuest.Name != null && r.MainGuest.Name.Contains(filter.GuestName));
        }

        var isFilterApplied = filter.ReservationId.HasValue ||
                          filter.StartDate.HasValue ||
                          filter.EndDate.HasValue ||
                          filter.StatusId > 0 ||
                          !string.IsNullOrEmpty(filter.GuestName);

        if (!isFilterApplied) {
            query = _context.Reservation
                .Include(r => r.Status)
                .Include(r => r.MainGuest);
        }
        
        int totalItems = query.Count();
        int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

        if(pageNumber < 1) pageNumber = 1;
        if(pageNumber > totalPages) pageNumber = totalPages;

        var paginatedReservations = query
            .Skip((pageNumber - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = pageNumber;

        return PartialView("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml", paginatedReservations);
    }
}
