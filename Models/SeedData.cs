using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PixelBase.Data;

namespace PixelBase.Models;

public static class SeedData
{
  public static async void Initialize(IServiceProvider serviceProvider)
  {
    // Seed users.
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var userId = await SeedUser(userManager, "admin", "Pix3lbase.");

    // Seed assets.
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
          Slug = "crunchy_rocks",
        },

        new Asset
        {
          Title = "wooden planks",
          Slug = "wooden_planks",
        },

        new Asset
        {
          Title = "grassy dirt",
          Slug = "grassy_dirt",

        }
      );

      context.SaveChanges();
    }
  }

  private static async Task<string> SeedUser(UserManager<IdentityUser> userManager, string userName, string userPassword)
  {
    var user = await userManager.FindByNameAsync(userName);

    if (user == null)
    {
      user = new IdentityUser(userName)
      {
        EmailConfirmed = true,
      };
      await userManager.CreateAsync(user, userPassword);
    }

    return user.Id;
  }
}