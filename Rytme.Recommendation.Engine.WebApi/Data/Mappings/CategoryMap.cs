using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

public class CategoryMap : NHibernateMap<Category>
{
    public CategoryMap()
    {
        Map(x => x.Name);
    }
}