using CleanApi.Domain.Shared;
using CleanApi.Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;
using CleanApi.Application.Employees;
using CleanApi.Domain.Employees;
using CleanApi.Infrastructure.Employees;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CleanApi.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Logging

            services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("in-mem-prod-database");
                    options.EnableSensitiveDataLogging(true);
                })
                .AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>()
                .AddScoped<IRepository<Employee>, EfRepository<Employee>>()
                .AddScoped<EmployeesQueryHandler>()
                .AddScoped<AddEmployeeCommandHandler>()
                .AddScoped<DeleteEmployeeCommandHandler>()
                //.AddScoped<IRepository<SomeModel>, EfRepository<SomeModel>>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(Startup).GetTypeInfo().Assembly)
                .AddSwaggerGen(config => config.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}))
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(config => config.MapControllers())
                .UseSwagger()
                .UseSwaggerUI(config => config.SwaggerEndpoint("v1/swagger.json", "API - V1"));
        }
    }
}
