using NHibernate;
using NHibernate.Linq;
using Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;
using ISession = NHibernate.ISession;

namespace Rytme.Recommendation.Engine.WebApi.Data.Base;

public abstract class NhRepository<TEntity> where TEntity : Entity
{
    private readonly ISession _session;

    protected NhRepository()
    {
        _session = NHibernateSessionManager.GetCurrentSession();
    }

    protected IQueryable<TEntity> Query()
    {
        var queryable = _session.Query<TEntity>()
            .WithOptions(opt => opt.SetCacheable(true))
            .WithOptions(opt => opt.SetCacheMode(CacheMode.Normal))
            .Where(entity => !entity.Deleted);

        return queryable;
    }

    protected bool SaveOrUpdate(TEntity entity)
    {
        var existing = Query().FirstOrDefault(x => x.Id == entity.Id);
        if (existing is not null) return false;

        using var transaction = _session.BeginTransaction();
        try
        {
            _session.SaveOrUpdate(entity);
            transaction.Commit();
            return true;
        }
        catch (Exception e)
        {
            transaction.Rollback();
            return false;
        }
    }

    protected bool Delete(long id)
    {
        var entity = Query().FirstOrDefault(x => x.Id == id);
        if (entity is null) return false;

        entity!.Deleted = true;
        return SaveOrUpdate(entity);
    }
}