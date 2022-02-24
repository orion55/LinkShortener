using System;
using LinkShortener.Core.Infrastructure;
using LinkShortener.Core.Infrastructure.MediatR;
using LinkShortener.Core.Infrastructure.Middlewares;
using LinkShortener.Core.Services.DbInitializer;
using LinkShortener.Db.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace LinkShortener
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeDatabaseAsync().Wait();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LinkShortener.API v1"));
            }
            
            app.UseSerilogRequestLogging();
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMiddleware<ValidationMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LinkDbContext>(options =>
            {
                options.UseNpgsql(
                    _configuration.GetConnectionString("DefaultConnection"),
                    builder => { builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null); });
                options.EnableSensitiveDataLogging(_webHostEnvironment.IsDevelopment());
            }, ServiceLifetime.Transient);
            
            services.AddTransient<IDbInitializerService, DbInitializerService>();
            services.AddMediatR(typeof(DummyCommand));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "LinkShortener.API", Version = "v1"});
            });
        }
    }
}