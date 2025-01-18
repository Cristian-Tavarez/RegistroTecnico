using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Components;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Services;

namespace RegistroTecnicos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddSingleton<Radzen.NotificationService>();
            builder.Services.AddBlazorBootstrap();

            // Agregando el Construtor
            var ConStr = builder.Configuration.GetConnectionString("ConStr");

            // Agregando el contexto
            builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

            //Inyectando service
            builder.Services.AddScoped<TecnicoServices>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}