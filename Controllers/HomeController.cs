using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PocFluentMigration.Infrastructure.Repositories;
using PocFluentMigration.Models;

namespace PocFluentMigration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IStateRepository _stateRepository;

    public HomeController(ILogger<HomeController> logger, IStateRepository stateRepository)
    {
        _logger = logger;
        _stateRepository = stateRepository;
    }

    public IActionResult Index()
    {
        var states = _stateRepository.All();

        return View(states);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
