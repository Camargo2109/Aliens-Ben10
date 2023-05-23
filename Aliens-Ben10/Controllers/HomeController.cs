using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aliens_Ben10.Models;
using Aliens.Services;

namespace Aliens_Ben10.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAliensBenServices _alienService;

    public HomeController(ILogger<HomeController> logger, IAliensBenServices alienService)
    {
        _logger = logger;
        _alienService = alienService;
    }

    public IActionResult Index(string tipo)
    {
        var aliens = _alienService.GetAliensDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(aliens);
    }

    public IActionResult Details(int Numero)
    {
        var aliens = _alienService.GetDetailedAliens(Numero);
        return View(aliens);
    }
    public IActionResult Privacy()
    {   
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
