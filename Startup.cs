using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LapTopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LapTopStore
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
            services.AddDbContext<LapTopStoreDbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:LapTopStoreConnection"]);
            });
            services.AddScoped<ILapTopStoreRepository,
           EFLapTopStoreRepository>();
            services.AddRazorPages();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<MyCart>(sp => MySessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILapTopStoreRepository, EFLapTopStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();

            services.AddServerSideBlazor();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("pagination","Laptops/{laptopPage}",
                //new { Controller = "Home", action = "Index" });
                //endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute("genpage","{genre}/{laptopPage:int}",
 
                   new { Controller = "Home", action = "TrangChu" });
                endpoints.MapControllerRoute("page", "{laptopPage:int}",
                new { Controller = "Home", action = "TrangChu", laptopPage = 1 });
                endpoints.MapControllerRoute("genre", "{genre}",
                new { Controller = "Home", action = "TrangChu", laptopPage = 1 });
                endpoints.MapControllerRoute("pagination",
                "Laptops/{laptopPage}",
                new { Controller = "Home", action = "TrangChu", laptopPage = 1 });
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                // admin
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}",
                "/Admin/Index");
            });
            SeedData.EnsurePopulated(app);
        }

    }
}

