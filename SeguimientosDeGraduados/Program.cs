using Microsoft.EntityFrameworkCore;
using SeguimientosDeGraduados.Components;
using SeguimientosDeGraduados.Models;

namespace SeguimientosDeGraduados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configuración del DbContext con cadena de conexión en appsettings.json
            builder.Services.AddDbContext<SeguimientoGraduadosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SeguimientoGraduados")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
