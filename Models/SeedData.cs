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
          Title = "Crunchy rocks",
        },

        new Asset
        {
          Title = "Wooden planks",
        },

        new Asset
        {
          Title = "Grassy dirt",
        }
      );

      context.SaveChanges();
    }
  }
}