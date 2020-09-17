using System;
using _3dIntiriorClients.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using _3dIntiriorClients.ErrorHandling;

namespace _3dIntiriorClients
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(8);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents();
                options.SlidingExpiration = false;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAccountData, AccountRepositary>();
            services.AddTransient<ICustomerData, CustomerRepositary>();
            services.AddTransient<IAdminData, AdminRepositary>();
            services.AddTransient<IGallaryData, GallaryRepository>();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
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
                app.UseHsts();
            }
            app.UseMiddleware<ErrorLoggingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
         
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=UserLogin}/{id?}");
            });
        }
    }
}
