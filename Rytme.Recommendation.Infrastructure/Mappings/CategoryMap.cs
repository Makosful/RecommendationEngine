using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Infrastructure.Mappings;

public class CategoryMap : NHibernateMap<Category>
{
    public CategoryMap()
    {
        Map(x => x.Name);
    }
}