using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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
            .Include(r => r.Observations)
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

        if (!isFilterApplied)
        {
            query = _context.Reservation
                .Include(r => r.Status)
                .Include(r => r.MainGuest);
        }

        int totalItems = query.Count();
        int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

        if (pageNumber < 1) pageNumber = 1;
        if (pageNumber > totalPages) pageNumber = totalPages;

        var paginatedReservations = query
            .Skip((pageNumber - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = pageNumber;
        ViewBag.Statuses = _context.Status.ToList();

        return PartialView("~/Views/Shared/Components/Reservations/ReservationsTable.cshtml", paginatedReservations);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationViewModel reservationViewModel)
    {
        if (reservationViewModel == null)
        {
            return BadRequest("Invalid reservation data.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (reservationViewModel.CpfCnpj == null)
        {
            return BadRequest("CpfCnpj Inválido.");
        }
        if (reservationViewModel.Email == null)
        {
            return BadRequest("Email Inválido.");
        }

        var existingGuest = _context.Guest.FirstOrDefault(g => g.CpfCnpj == reservationViewModel.CpfCnpj);
        Guest guest;

        if (existingGuest != null)
        {
            guest = existingGuest;
        }
        else
        {
            guest = new Guest
            {
                Name = reservationViewModel.Name,
                CpfCnpj = reservationViewModel.CpfCnpj,
                Email = reservationViewModel.Email,
                Telefone = reservationViewModel.Phone,
                Cep = reservationViewModel.ZipCode,
                Endereco = reservationViewModel.Address,
                Numero = reservationViewModel.AddressNumber,
                Complemento = reservationViewModel.Complement,
                Bairro = reservationViewModel.Neighborhood,
                Cidade = reservationViewModel.City,
                Estado = reservationViewModel.State
            };

            // Add new guest to the database
            _context.Guest.Add(guest);
            _context.SaveChanges();
        }

        var ActiveStatus = _context.Status.Where(s => s.Id == 1).First();

        // Create the reservation
        var reservation = new Reservation
        {
            StartDate = reservationViewModel.StartDate,
            EndDate = reservationViewModel.EndDate,
            Observations = reservationViewModel.Observations,
            Status = ActiveStatus,
            StatusId = ActiveStatus.Id, 
            MainGuestId = guest.Id,
            MainGuest = guest,
            AdditionalGuests = reservationViewModel.AdditionalGuests
        };

        _context.Reservation.Add(reservation);
        _context.SaveChanges();

        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult UpdateReservation(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            var existingReservation = _context.Reservation.Find(reservation.Id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.StartDate = reservation.StartDate;
            existingReservation.EndDate = reservation.EndDate;
            existingReservation.Observations = reservation.Observations;
            existingReservation.StatusId = reservation.StatusId;

            _context.SaveChanges();

            return Json(new { success = true });
        }

        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
    }

    [HttpPost]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = _context.Reservation.Find(id);
        if (reservation == null)
        {
            return NotFound();
        }

        _context.Reservation.Remove(reservation);
        _context.SaveChanges();

        return Json(new { success = true });
    }
}
