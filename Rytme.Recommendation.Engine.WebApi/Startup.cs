using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Rytme.Recommendation.Engine.WebApi.GraphQL;

namespace Rytme.Recommendation.Engine.WebApi;

public class Startup
{
    private readonly string _connectionString;

    public Startup(IConfiguration configuration)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddGraphQlServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
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