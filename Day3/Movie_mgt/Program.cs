using Microsoft.EntityFrameworkCore;
using Movies.Services.Services;
using Movies.DataAccess;
using Movies.DataAccess.Repositories;



public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<MovieServices>();
        builder.Services.AddDbContext<MovieDbContext>(db =>
            db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); 
        builder.Services.AddScoped<MovieRepository, MovieRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}