using IntellveDashboard.UI.Extensions;
using IntellveDashboard.UI.Models;
using IntellveDashboard.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace IntellveDashboard.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            NLog.LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.ConfigureLoggerService();

            services.AddAuthorization(options => {
                options.AddPolicy("RequireSuperUserRole", policy => policy.RequireRole("Super User"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Dashboard");
                //options.Conventions.AuthorizePage("/Contact"); // can not redirect to contact page without login                     
                //options.Conventions.AuthorizeFolder("/Private");
                //options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAlertService, AlertService>();
            services.AddScoped<JsonServicesHelper>();
            services.Configure<ConfigSettingsModel>(Configuration.GetSection("ConfigurationSettings"));
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //env.EnvironmentName = EnvironmentName.Development;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");

                app.ConfigureCustomExceptionMiddleware();

                app.UseHsts();
            }
             
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication(); 

            //app.UseStatusCodePages(async context =>
            //{
            //    context.HttpContext.Response.ContentType = "text/plain";

            //    await context.HttpContext.Response.WriteAsync(
            //        "Status code page, status code: " +
            //        context.HttpContext.Response.StatusCode);
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
