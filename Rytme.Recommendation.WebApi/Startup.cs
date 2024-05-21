using Rytme.Recommendation.Infrastructure.Base;
using Rytme.Recommendation.WebApi.GraphQL;

namespace Rytme.Recommendation.WebApi;

public class Startup
{
    private readonly string _connectionString;

    public Startup(IConfiguration configuration)
    {
        _connectionString = $"Server={configuration["DB_ADDR"]};" +
                            $"Port={configuration["DB_PORT"]};" +
                            $"Database={configuration["DB_NAME"]};" +
                            $"Uid={configuration["DB_USER"]};" +
                            $"Pwd={configuration["DB_PASS"]};" +
                            "SslMode=Preferred;";
    }

    public void ConfigureServices(IServiceCollection services)
    {
        NHibernateSessionManager.ConnectionString = _connectionString;

        services.AddControllers();
        services.AddGraphQlServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            var session = NHibernateSessionManager.GetCurrentSession();
        }

        app.UseRouting();
        app.UseWebSockets();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGraphQL();
        });
    }
}