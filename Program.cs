using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ----- Base de données -----
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// ----- Contrôleurs + Swagger -----
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----- Services Repository -----
builder.Services.AddTransient<IGenresService, GenresService>();
builder.Services.AddTransient<IMoviesService, MoviesService>();

// ----- AutoMapper -----
builder.Services.AddAutoMapper(typeof(Program));

// ----- CORS -----
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();