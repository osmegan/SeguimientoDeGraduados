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

            // Servicios de Blazor
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Registrar el DbContext con la cadena de conexión
            builder.Services.AddDbContext<SeguimientoGraduadosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SeguimientoGraduados")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
