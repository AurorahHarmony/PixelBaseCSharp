using Microsoft.AspNetCore.Mvc;

namespace PixelBase.Controllers;

public class SessionController : Controller
{
  [HttpGet("/login")]
  public IActionResult Login()
  {
    return View();
  }
}