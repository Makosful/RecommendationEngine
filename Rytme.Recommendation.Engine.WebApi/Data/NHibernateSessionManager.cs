using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Caches.CoreMemoryCache;
using NHibernate.Context;
using ISession = NHibernate.ISession;

namespace Rytme.Recommendation.Engine.WebApi.Data;

public static class NHibernateSessionManager
{
    private static ISessionFactory Factory { get; set; }
    public static string ConnectionString { get; set; } = string.Empty;

    private static ISessionFactory GetFactory<T>() where T : ICurrentSessionContext
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
            throw new InvalidOperationException("Connection String has not been set");

        return Fluently.Configure()
            .Database(MySQLConfiguration.Standard
                .ConnectionString(c => c.Is(ConnectionString)))
            .Cache(c => c.UseQueryCache().ProviderClass<CoreMemoryCacheProvider>().UseSecondLevelCache())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IAssemblyMarker>()
                .Conventions.Add(Table.Is(x => x.TableName.ToLower()))) // lowercase table names
            .CurrentSessionContext<T>().BuildSessionFactory();
    }

    public static ISession GetCurrentSession()
    {
        try
        {
            if (CurrentSessionContext.HasBind(Factory))
                return Factory.GetCurrentSession();
        }
        catch
        {
            Factory = GetFactory<ThreadStaticSessionContext>();
        }

        var session = Factory.OpenSession();
        CurrentSessionContext.Bind(session);

        return session;
    }
}