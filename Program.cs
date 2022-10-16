using Microsoft.EntityFrameworkCore;
using PixelBase.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Database.
if (builder.Environment.IsDevelopment())
{
  builder.Services.AddDbContext<PixelBaseContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("PixelBaseContext") ?? throw new InvalidOperationException("Connection string 'PixelBaseContext' not found.")));
}
else
{
  builder.Services.AddDbContext<PixelBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionPixelBaseContext")));
}

var app = builder.Build();

// Seed the database.
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/ServerError");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
// app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "asset",
  pattern: "asset/{*index}",
  defaults: new { controller = "Asset", action = "Index" }
);

app.Run();
