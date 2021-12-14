using FluentNHibernate.Mapping;
using Rytme.Recommendation.Core.Entity.Abstractions;

namespace Rytme.Recommendation.Infrastructure.Mappings;

public abstract class NHibernateMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
{
    public NHibernateMap()
    {
        Cache.ReadWrite();
        Id(x => x.Id);
        Map(x => x.Deleted);
    }
}