using Arvan.Try.SimplaeApi.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Arvan.Try.SimpleApi.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) =>
            _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseOptions>(
               _configuration.GetSection(nameof(DatabaseOptions)),
               opt => _configuration.Bind(opt));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(e =>
            {
                e.MapGet("/", async a => await a.Response.WriteAsync("Arvan.Try.SimpleApi.Api"));
                e.MapControllers();
            });
        }
    }
}
