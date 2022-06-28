using Business.Implementation;
using BusinessServiceContract.Services;
using DataAccess.Repositories;
using DataAccessSeviceContract.Services;
using DomainModel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop
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
            services.AddDbContext<EshopContext>(optionsAction => 
            {
                optionsAction.UseSqlServer(Configuration["ConnectionString"]);
            },
            ServiceLifetime.Scoped);

            //if Multi Context Use Below DbContext and configuration
            //services.AddDbContext<EshopContext>(optionsAction =>
            //{
            //    optionsAction.UseSqlServer(Configuration["ConnectionString"]);
            //},
            //ServiceLifetime.Scoped);
            services.AddScoped<ISupplierBusiness, SupplierBusiness>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
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
                app.UseExceptionHandler("/Home/Error");
            }
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
