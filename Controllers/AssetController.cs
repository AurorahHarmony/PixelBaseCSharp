using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixelBase.Data;
using PixelBase.Models;

namespace PixelBase.Controllers;


public class AssetController : Controller
{
  private readonly PixelBaseContext _context;
  private readonly IWebHostEnvironment _hostEnvironment;

  public AssetController(PixelBaseContext context, IWebHostEnvironment hostEnvironment)
  {
    _context = context;
    _hostEnvironment = hostEnvironment;
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
  [Authorize]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost("/asset/new")]
  [Authorize]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("Id,Slug,Title,Description,ImageFile,ZipFile")] Asset asset)
  {
    if (ModelState.IsValid)
    {
      // Save image to wwwroot/upload
      if (asset.ImageFile != null)
      {
        string wwwRootPath = _hostEnvironment.WebRootPath;
        string filename = Path.GetFileNameWithoutExtension(asset.ImageFile.FileName);
        string extension = Path.GetExtension(asset.ImageFile.FileName);
        asset.ImageName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        string path = Path.Combine(wwwRootPath + "/upload/", filename);
        using (var filestream = new FileStream(path, FileMode.Create))
        {
          await asset.ImageFile.CopyToAsync(filestream);
        }
      }
      // Save zip file
      if (asset.ZipFile != null)
      {
        string wwwRootPath = _hostEnvironment.WebRootPath;
        string filename = Path.GetFileNameWithoutExtension(asset.ZipFile.FileName);
        string extension = Path.GetExtension(asset.ZipFile.FileName);
        asset.ZipName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        string path = Path.Combine(wwwRootPath + "/upload/", filename);
        using (var filestream = new FileStream(path, FileMode.Create))
        {
          await asset.ZipFile.CopyToAsync(filestream);
        }
      }

      _context.Add(asset);
      await _context.SaveChangesAsync();
      return Redirect($"/asset/{asset.Id}");
    }
    return View(asset);
  }

  [HttpGet("/asset/{id:int}/delete")]
  [Authorize]
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null || _context.Asset == null)
    {
      return NotFound();
    }

    var asset = await _context.Asset
    .FirstOrDefaultAsync(a => a.Id == id);
    if (asset == null)
    {
      return NotFound();
    }
    _context.Asset.Remove(asset);
    await _context.SaveChangesAsync();

    return Redirect("/search");

  }
}