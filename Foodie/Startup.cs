using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Logging;
using Foodie.Services;
using System.Linq;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Foodie
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public IConfiguration Configuration { get; }
        public ILogger<Startup> Logger { get; }
        private ApplicationDbContext _dbContext;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IMealsService, MealsService>();
            services.AddTransient<IIngriedientsService, IngriedientService>();
            services.AddTransient<IDayDataService, DayDataService>();



            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt().AddJwtBearer(options =>
                {
                    options.Authority = "https://walltedo.com/";
                });
            services.AddControllersWithViews().AddNewtonsoftJson(x => {
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                x.SerializerSettings.MaxDepth=64;
                });
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });
        }
        public void ApplyMigrations(ApplicationDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            var options = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };

            // Clear the forward headers networks so any ip can forward headers
            // Should ONLY do this in dev/testing
            // options.KnownNetworks.Clear();
            // options.KnownProxies.Clear();

            // For security you should limit the networks that can forward headers
            // Adding a network with a mask
            //options.KnownNetworks.Add(new IPNetwork(IPAddress.Parse("::ffff:111.12.0.0"), 16));
            // OR Adding specific ips
            options.KnownProxies.Add(IPAddress.Parse("::ffff:46.101.125.72"));
            //options.KnownProxies.Add(IPAddress.Parse("::ffff:10.0.1.3"));

            app.UseForwardedHeaders(options);
            app.Use(async (ctx, next) =>
            {
                ctx.Request.Headers.TryGetValue("X-Forwarded-Proto", out StringValues value);
                if (!string.IsNullOrEmpty(value))
                {
                    ctx.Request.Scheme = value;
                }
                await next();
            });

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            this.ApplyMigrations(dbContext);
        }
    }
}
