
using Microsoft.EntityFrameworkCore;
using RecordApplication.Models;
using RecordApplication.Services;

namespace RecordApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //string connectionString = builder.Configuration.GetConnectionString("DevelopmentConnectionString");

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IAlbumsService, AlbumsService>();
            builder.Services.AddTransient<IAlbumsModel, AlbumsModel>();
            builder.Services.AddTransient<IArtistService, ArtistService>();
            builder.Services.AddTransient<IArtistModel, ArtistModel>();

            if (builder.Environment.IsDevelopment())
            {
                //builder.Services.AddDbContext<AlbumDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
                builder.Services.AddDbContext<AlbumDbContext>(options => options.UseSqlServer("DefaultConnectionString"));
            }
            else if (builder.Environment.IsProduction()) 
            {
                builder.Services.AddDbContext<AlbumDbContext>(options => options.UseSqlServer("DefaultConnectionString"));
            }

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
