using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WarehouseManagement.Domain.Context;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.Interfaces.Services;
using WarehouseManagement.Infrastructure;
using WarehouseManagement.Service;

namespace WarehouseManagement.API
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
            services.AddDbContext<WarehouseContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });
            services.AddIdentity<Employee, EmployeeType>().AddEntityFrameworkStores<WarehouseContext>();
            services.AddIdentityCore<Employee>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            });

            services.AddScoped<DatabaseContext, WarehouseContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductUnitService, ProductUnitService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WarehouseManagement.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}