using MarvelApI.Data;
using MarvelApI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<MarvelContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 26))));

// Register services for dependency injection
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();

// Add services for controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed the database
SeedData.Initialize(app.Services);

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
