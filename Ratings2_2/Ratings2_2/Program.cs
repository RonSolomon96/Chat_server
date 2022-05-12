using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ratings2_2.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Ratings2_2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ratings2_2Context") ?? throw new InvalidOperationException("Connection string 'Ratings2_2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RatingObjs}/{action=Index}/{id?}");

app.Run();
