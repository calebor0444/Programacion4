using DemoMVC.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Asegurar que se carga desde User Secrets en Development
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Obtener la cadena de conexión
            var connectionString = GetConnectionString(builder);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Cadena de conexión no configurada. " +
                    $"Ambiente: {builder.Environment.EnvironmentName}. " +
                    $"Para Development: Usar appsettings.Development.json. " +
                    $"Para Production: Usar variable de entorno CHINOOK_CONNECTION_STRING."
                );
            }

            // Agregar el DbContext
            builder.Services.AddDbContext<ChinookContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static string? GetConnectionString(WebApplicationBuilder builder)
        {
            // En Production: Leer desde variable de entorno (más seguro)
            if (builder.Environment.IsProduction())
            {
                var envConnectionString = Environment.GetEnvironmentVariable("CHINOOK_CONNECTION_STRING");
                if (!string.IsNullOrEmpty(envConnectionString))
                {
                    return envConnectionString;
                }
                // Fallback a appsettings si existe
                return builder.Configuration.GetConnectionString("ChinookConnection");
            }

            // En Development: Leer desde appsettings.Development.json
            return builder.Configuration.GetConnectionString("ChinookConnection");
        }
    }
}
