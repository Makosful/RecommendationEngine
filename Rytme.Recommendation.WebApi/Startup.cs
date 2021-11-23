using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rytme.Recommendation.WebApi
{
    public class Startup
    {
        private readonly string _connectionString;

        public Startup(IConfiguration configuration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Server={configuration["DB_ADDR"]};");
            stringBuilder.Append($"Port={configuration["DB_PORT"]};");
            stringBuilder.Append($"Database={configuration["DB_NAME"]};");
            stringBuilder.Append($"Uid={configuration["DB_USER"]};");
            stringBuilder.Append($"Pwd={configuration["DB_PASS"]};");
            stringBuilder.Append($"SslMode=Preferred;");
            _connectionString = stringBuilder.ToString();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                var factory = Seed.BuildDatabase(_connectionString);
                Seed.SeedDatabase(factory);
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}