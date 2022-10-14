using Microsoft.AspNetCore.Mvc;

namespace PixelBase.Controllers;

public class SearchController : Controller
{

  public IActionResult Index()
  {
    return View();
  }

}