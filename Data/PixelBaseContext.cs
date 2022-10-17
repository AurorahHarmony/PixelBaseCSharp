using Microsoft.EntityFrameworkCore;
using PixelBase.Models;

namespace PixelBase.Data;

public class PixelBaseContext : DbContext
{
  public PixelBaseContext(DbContextOptions<PixelBaseContext> options)
    : base(options)
  {
  }

  public DbSet<PixelBase.Models.Asset> Asset { get; set; } = default!;
}
