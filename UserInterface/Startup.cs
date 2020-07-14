using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Categories;
using Business.ProductTaxes;
using Business.Proucts;
using Business.SubCategories;
using Business.Taxes;
using DataAccess.Categories;
using DataAccess.Products;
using DataAccess.ProductTaxes;
using DataAccess.SubCategories;
using DataAccess.Taxes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserInterface.Data;

namespace UserInterface
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
            services.AddScoped<RouterTax>();
            services.AddScoped<RouterProductTax>();
            services.AddScoped<RouterCategory>();
            services.AddScoped<RouterSubCategory>();
            services.AddScoped<ICategory, ImplementerCategory>();
            services.AddScoped<ISubCategory, ImplementerSubCategory>();
            services.AddScoped<ITax, ImplementerTax>();
            services.AddScoped<IProductTax, ImplementerProductTax>();
            services.AddScoped<IProduct, ImplementerProduct>();


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
