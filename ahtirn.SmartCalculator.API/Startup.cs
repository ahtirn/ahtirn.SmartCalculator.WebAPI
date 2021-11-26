using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using ahtirn.BusinessLogic.Services;
using ahtirn.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ahtirn.SmartCalculator.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ahtirn.SmartCalculator.API", Version = "v1" });
            });
            services.AddTransient<IUsersService, UsersService>();
            services.AddScoped<ILogService, LoggerUsersServiceNew>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, ILogService logService)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ahtirn.SmartCalculator.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            // Logs input data from the controller into a "log_file.log".
            app.Use(async (context, next) =>
            {
                await logService.LogAsync(context.Request);
                await next.Invoke();
            });
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}