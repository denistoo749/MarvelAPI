using Microsoft.EntityFrameworkCore;
using MarvelApI.Data;
using MarvelAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<MarvelContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 26))));

// Register services for dependency injection
builder.Services.AddScoped<CharactersRepository>();
builder.Services.AddScoped<MoviesRepository>();
builder.Services.AddScoped<PlanetsRepository>();
builder.Services.AddScoped<SeriesRepository>();


// Add services for controllers
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database
SeedData.Initialize(app.Services);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();