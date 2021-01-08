  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace ProyectoFinalVoleibol
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
            options =>
            {
                options.LoginPath = "/Home/IniciarSesion";
                options.LogoutPath = "/Home/CerrarSesion";
               
                options.Cookie.Name = "ControlUsuarios";

                options.LoginPath = "/Home/DtInicioSesion";
                
                options.AccessDeniedPath = "/Home/Denegado";
                options.Cookie.Name = "Final5";
            });
            services.AddMvc();
            services.AddSingleton<ProyectoFinalVoleibol.Services.MenuServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public IWebHostEnvironment Environment { get; set; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Environment = env;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseFileServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });
        }
    }
}