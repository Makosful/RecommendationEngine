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
        _connectionString = $"Server={configuration["DB_ADDR"]};" +
                            $"Port={configuration["DB_PORT"]};" +
                            $"Database={configuration["DB_NAME"]};" +
                            $"Uid={configuration["DB_USER"]};" +
                            $"Pwd={configuration["DB_PASS"]};" +
                            "SslMode=Preferred;";
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
            var factory = BuildDatabase();
        }

        app.UseRouting();
        app.UseWebSockets();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGraphQL();
        });
    }

    private ISessionFactory BuildDatabase()
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
            throw new InvalidOperationException("Connection String is empty");

        var fluentConfiguration = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
            .Mappings(map => map.FluentMappings.AddFromAssemblyOf<IAssemblyMarker>()
                .Conventions.Add(Table.Is(table => table.TableName.ToLower())));

        var factory = fluentConfiguration
            .ExposeConfiguration(x => new SchemaUpdate(x).Execute(true, true))
            .BuildConfiguration()
            .BuildSessionFactory();

        using var session = factory.OpenSession();
        if (!session.IsConnected)
            throw new InvalidOperationException("Cannot establish connection to the database");

        return factory;
    }
}