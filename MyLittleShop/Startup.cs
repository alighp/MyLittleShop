using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLittleShop.Persistance;
using MyLittleShop.Repositories;
using MyLittleShop.Service;
using MyLittleShop.Service.GoodCategories;
using MyLittleShop.Service.GoodCategories.Contracts;
using MyLittleShop.Service.GoodEntries;
using MyLittleShop.Service.GoodEntries.Contracts;
using MyLittleShop.Service.Goods;
using MyLittleShop.Service.Goods.Contracts;
using MyLittleShop.Service.GoodSales;
using MyLittleShop.Service.GoodSales.Contracts;

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
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("Server=.;Database=MyLittleShop2;Trusted_Connection=True;"));
            services.AddScoped<IGoodEntryRepository, GoodEntryRepository>();
            services.AddScoped<IGoodSaleRepository, GoodSaleRepository>();
            services.AddScoped<IGoodRepository, GoodRepository>();
            services.AddScoped<IGoodCategoryRepository, GoodCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IGoodSaleService, GoodSaleService>();
            services.AddScoped<IGoodEntryService, GoodEntryService>();
            services.AddScoped<IGoodCategoryService, GoodCategoryService>();
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
