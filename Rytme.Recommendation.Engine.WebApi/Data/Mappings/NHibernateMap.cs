using FluentNHibernate.Mapping;
using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

public abstract class NHibernateMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
{
    public NHibernateMap()
    {
        Cache.ReadWrite();
        Id(x => x.Id);
        Map(x => x.Deleted);
    }
}