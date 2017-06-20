using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using SampleProject.Services;
using Microsoft.Extensions.Configuration;
using SampleProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace SampleProject
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(environment.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IProductRepository, EfProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute("MyRoute", "Engine/{controller=Home}/{action=Index3}/{id?}");
        }
    }
}
