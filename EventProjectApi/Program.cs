
using EventProjectApi.Controllers.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventProjectApi
{
    
    //pipeline !!
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>   //   Registriert er Db Context 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")); // Datenbank Verbindung
            });
            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle   //UI Seite
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();                    // Aufbau von Service

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())          // Entwicklungsmodus aoll sich die UI öffnen (Button benutzen kannst über die Seite)
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
