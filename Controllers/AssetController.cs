using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixelBase.Data;
using PixelBase.Models;

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

  [HttpGet("/asset/new")]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost("/asset/new")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Asset asset)
  {
    if (ModelState.IsValid)
    {
      var newAsset = _context.Add(asset);
      await _context.SaveChangesAsync();
      return Redirect($"/asset/{asset.Id}");
    }
    return View(asset);
  }
}