using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proj1.BusinessLogic;
using Proj1.DataLogic;
using Proj1.Models;

namespace Proj1
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
            services.AddDbContext<Proj1Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Proj1Context")));

            services.AddControllersWithViews();

             services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDefaultStoreRepository, DefaultStoreRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderListRepository, OrderListRepository>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                        options.LoginPath = "/CustomerLogin/UserLogin";
                        //options.AccessDeniedPath = "/Account/AccessDenied";
                        //options.SlidingExpiration = true;
                    });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "Admin",
                    policyBuilder => policyBuilder.RequireRole("Admin"));
                options.AddPolicy(
                    "Customer",
                    policyBuilder => policyBuilder.RequireRole("Customer")); 
                options.AddPolicy(
                    "LoggedIn",
                    policyBuilder => policyBuilder.RequireRole(new string[] { "Customer", "Admin" }));
            });

            services.AddSession();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
