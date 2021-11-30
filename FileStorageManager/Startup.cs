using System;
using FileStorageManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetChatApp.Areas.Identity.Data;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using AuthServer;
using System.Reflection;

namespace FileStorageManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            string connectionString = Configuration.GetConnectionString("Default");
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<StorageDbContext>(options => options.UseMySQL(connectionString));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<StorageDbContext>().AddDefaultTokenProviders();
            //services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MyDbContext>();

            services.AddIdentityServer().AddDeveloperSigningCredential().AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseMySQL(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30; // interval in seconds
            })
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiScopes(Config.GetApiScopes())
            .AddInMemoryClients(Config.GetClients())
            .AddAspNetIdentity<AppUser>();
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
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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
        }
    }
}
