using Microsoft.EntityFrameworkCore;
using SeguimientosDeGraduados.Components;
using SeguimientosDeGraduados.Models; // <- tu carpeta Models generada por Scaffold

namespace SeguimientosDeGraduados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // 🔹 Aquí registramos el DbContext con la cadena de conexión del appsettings.json
            builder.Services.AddDbContext<SeguimientoGraduadosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SeguimientoGraduados")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
