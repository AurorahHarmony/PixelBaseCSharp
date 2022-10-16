using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixelBase.Models;

namespace PixelBase.Controllers;

public class SearchController : Controller
{
  private readonly PixelBaseContext _context;
  public SearchController(PixelBaseContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index(string query)
  {
    var assets = from a in _context.Asset select a;

    if (!String.IsNullOrEmpty(query))
    {
      assets = assets.Where(s => s.Title!.Contains(query));
    }

    ViewData["SearchQuery"] = query;
    return View(await assets.ToListAsync());
  }

}