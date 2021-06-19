using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyLittleShop.Controllers;
using MyLittleShop.Model;
using MyLittleShop.Persistance;
using MyLittleShop.Repositories;
using MyLittleShop.Service;
using MyLittleShop.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(x=>x.UseSqlServer("Server=.;Database=MyLittleShop2;Trusted_Connection=True;"));
            services.AddScoped<IGoodEntryRepository,GoodEntryRepository>();
            services.AddScoped<IGoodSaleRepository,GoodSaleRepository>();
            services.AddScoped<IGoodRepository,GoodRepository>();
            services.AddScoped<IGoodCategoryRepository,GoodCategoryRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HttpReplApi v1");
            });

        }
    }
}
