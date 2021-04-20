using Interview.Api.Helpers;
using Interview.Application.Transformers;
using Interview.Application.UseCases;
using Interview.Repository.DapperRepository;
using Interview.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Interview.Api
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
            services.AddCors();
            services.AddControllers();

            services.AddScoped<IImportEmployees, ImportEmployees>();
            services.AddScoped<ITransformEmployeeFile, EmployeeCsvTransformer>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFileConvertor, FileConvertor>();
            services.AddScoped<IRepository, DapperRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\Log.txt");

            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder=> builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
