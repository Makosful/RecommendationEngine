using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Rytme.Recommendation.WebApi
{
    public static class Seed
    {
        public static ISessionFactory BuildDatabase(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection String is not set");

            FluentConfiguration configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(maps => maps.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(IAssemblyMarker)))
                    .Conventions.Add(Table.Is(x=>x.TableName.ToLower())));

            ISessionFactory factory = configuration
                .ExposeConfiguration(x => new SchemaUpdate(x).Execute(true, true))
                .BuildConfiguration()
                .BuildSessionFactory();

            using var session = factory.OpenSession();
            if (!session.IsConnected)
                throw new InvalidOperationException("Database connection could not be established");

            return factory;
        }
        
        public static void SeedDatabase(ISessionFactory factory)
        {
        }
    }
}