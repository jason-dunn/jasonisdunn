using Blazored.LocalStorage;
using Blazored.SessionStorage;
using jasonisdunn.Data;
using jasonisdunn.Shared.States;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using System.Linq;
using System.Net.Http;

namespace jasonisdunn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IncrementService>();
            services.AddSingleton<AssemblyVersionService>();
            services.AddSingleton<StatusService>();
            services.AddSingleton<EmailFormModel>();
            services.AddSingleton<SMTPService>();
            services.AddSingleton<GuidGeneratorService>();
            services.AddSingleton<CodeGeneratorService>();
            services.AddScoped<MainState>();
            services.AddSingleton<PageHistoryState>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => sp.GetRequiredService<HttpContext>().Request);
            services.AddScoped(sp => sp.GetRequiredService<HttpContext>().Response);
            services.AddScoped(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext);

            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                services.AddScoped<HttpClient>(s =>
                {
                    var uriHelper = s.GetRequiredService<NavigationManager>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.BaseUri)
                    };
                });
            }   
            services.AddMudServices();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
