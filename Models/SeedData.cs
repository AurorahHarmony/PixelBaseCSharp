using Microsoft.EntityFrameworkCore;

namespace PixelBase.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new PixelBaseContext(
      serviceProvider.GetRequiredService<
        DbContextOptions<PixelBaseContext>>()))
    {

      if (context.Asset.Any())
      {
        return;
      }

      context.Asset.AddRange(
        new Asset
        {
          Title = "crunchy rocks",
        },

        new Asset
        {
          Title = "wooden planks",
        },

        new Asset
        {
          Title = "grassy dirt",
        }
      );

      context.SaveChanges();
    }
  }
}