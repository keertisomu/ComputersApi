using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersApi.Models;
using ComputersApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComputersApi
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("ComputersDB"));
            services.AddSingleton(typeof(IRepository<Computer>), new ComputerRepository());
            services.AddControllers();
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<ApiContext>();
            AddSeedData(service);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddSeedData(ApiContext context)
        {
            var testComputer1 = new Computer
            {
                Id = "c123",
                ComputerType = Enums.ComputerType.Laptop,
                Brand = "Dell",
                Processor = "Intel"
            };

            context.Computers.Add(testComputer1);

            var testComputer2 = new Computer
            {
                Id = "c234",
                ComputerType = Enums.ComputerType.DesktopPc,
                Brand = "HP",
                Processor = "AMD"
            };

            context.Computers.Add(testComputer2);

            context.SaveChanges();
        }
    }
}
