using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MomentumTest.Models;

namespace MomentumTest.Controllers;

public class ReservationsController(ILogger<ReservationsController> logger) : Controller
{
    private readonly ILogger<ReservationsController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}
