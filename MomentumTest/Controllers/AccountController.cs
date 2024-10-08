using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MomentumTest.Models;

namespace MomentumTest.Controllers;

public class AccountController(ILogger<AccountController> logger) : Controller
{
    private readonly ILogger<AccountController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}
