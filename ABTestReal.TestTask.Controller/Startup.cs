using ABTestReal.TestTask.DAL.Context;
using ABTestReal.TestTask.DAL.Reposirories;
using ABTestReal.TestTask.Interfaces.Reposirories;
using ABTestReal.TestTask.Interfaces.RollingRetentioService;
using ABTestReal.TestTask.Services.RollingRetentioService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTestReal.TestTask.Controller
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
            services.AddDbContext<DataDb>(
                opt => opt
                .UseNpgsql(Configuration.GetConnectionString("Data"), o => o.MigrationsAssembly("ABTestReal.TestTask.DAL.PostgreSQL")));

            services.AddScoped(typeof(IRepository<>), typeof(DbReposirory<>));
            services.AddScoped(typeof(IRollingRetentionService<>), typeof(RollingRetentionService<>));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ABTestReal.TestTask.Controller", Version = "v1" });
            });
        }
    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ABTestReal.TestTask.Controller v1"));
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
