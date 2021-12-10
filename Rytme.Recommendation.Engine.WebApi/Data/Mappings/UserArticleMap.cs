using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

public class UserArticleMap : NHibernateMap<UserArticle>
{
    public UserArticleMap()
    {
        Map(x => x.UserId);
        Map(x => x.ArticleId);
        Map(x => x.Score);
    }
}