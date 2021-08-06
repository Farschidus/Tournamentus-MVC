using Tournamentus.Core.Data;
using Tournamentus.Core.Data.Identity;
using Tournamentus.Core.Infrastructure;
using Tournamentus.WebApp.Extensions;
using Tournamentus.WebApp.Infrastructure;
using Tournamentus.WebApp.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;

namespace Tournamentus.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = CreateSettings();

            services.AddDbContext<TournamentusDb>(options =>
            {
                options.UseSqlServer(settings.ConnectionStrings.TournamentusDb);
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<TournamentusDb>();

            services
                .AddControllersWithViews(options =>
                {
                    // Add Cross Site Request Forgery Validation
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    options.EnableEndpointRouting = false;

                    options.ModelMetadataDetailsProviders.Add(new NullToEmptyStringProvider());
                })
                .AddFeatureFolders();

            services.AddAntiforgery(options => options.HeaderName = "X-AT-XSRF-TOKEN");

            services.AddHttpClient();

            if (!Environment.IsDevelopment())
            {
                services.AddHsts(options =>
                {
                    options.Preload = true;
                    options.IncludeSubDomains = true;
                    options.MaxAge = TimeSpan.FromDays(365);
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Redirects HTTP requests to HTTPS
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = content =>
                {
                    if (content.File.Name.EndsWith(".js.gz", StringComparison.OrdinalIgnoreCase))
                    {
                        content.Context.Response.Headers[HeaderNames.ContentType] = "text/javascript";
                        content.Context.Response.Headers[HeaderNames.ContentEncoding] = "gzip";
                    }

                    if (!string.IsNullOrEmpty(content.Context.Request.Query["v"]))
                    {
                        content.Context.Response.Headers.Add("cache-control", new[] { "public,max-age=31536000" });
                        content.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddYears(1).ToString("R") }); // Format RFC1123
                    }
                },
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("site", "Sites/{siteId:int}/{controller}/{action}/{id?}", defaults: new { controller = "Customers", action = "Index" });
                //endpoints.MapControllerRoute("user", "Users/{userId:int}/{action}/{id?}", defaults: new { controller = "Users", action = "Index" });
                //endpoints.MapControllerRoute("customer", "Customers/{customerId:int}/{action}/{id?}", defaults: new { controller = "Customers", action = "Index" });
                endpoints.MapControllerRoute("default_route", "{controller}/{action}", defaults: new { controller = "Home", action = "Index" });
            });
        }

        private AppSettings CreateSettings()
        {
            var connectionStrings = Configuration.Bind<ConnectionStringSettings>("ConnectionStrings");

            var settings = new AppSettings(connectionStrings);

            return settings;
        }
    }
}
