using Microsoft.EntityFrameworkCore;
using PixelBase.Models;

public class PixelBaseContext : DbContext
{
  public PixelBaseContext(DbContextOptions<PixelBaseContext> options)
    : base(options)
  {
  }

  public DbSet<PixelBase.Models.Asset> Asset { get; set; } = default!;
}
