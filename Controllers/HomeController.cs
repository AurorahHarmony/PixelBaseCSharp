using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PixelBase.Models;

namespace PixelBase.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult ServerError()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  [Route("/Home/Error/{code:int}")]
  public IActionResult Error(int code)
  {
    ViewData["ErrorCode"] = code;
    switch (code)
    {
      case 404:
        ViewData["ErrorMsg"] = "Page not found";
        break;
      default:
        ViewData["ErrorMsg"] = "Unknown";
        break;
    }
    return View("~/Views/Shared/Error.cshtml");
  }
}
