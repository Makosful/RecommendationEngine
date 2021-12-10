using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

public class ArticleMap : NHibernateMap<Article>
{
    public ArticleMap()
    {
        Map(x => x.Title);
    }
}