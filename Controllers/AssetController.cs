using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PixelBase.Controllers;


public class AssetController : Controller
{
  private readonly PixelBaseContext _context;

  public AssetController(PixelBaseContext context)
  {
    _context = context;
  }

  [HttpGet("/asset/{slug:int}")]
  public async Task<IActionResult> Index(int? slug)
  {
    if (slug == null || _context.Asset == null)
    {
      return NotFound();
    }

    var asset = await _context.Asset
  .FirstOrDefaultAsync(a => a.Id == slug);

    if (asset == null)
    {
      return NotFound();
    }

    return View(asset);
  }
}