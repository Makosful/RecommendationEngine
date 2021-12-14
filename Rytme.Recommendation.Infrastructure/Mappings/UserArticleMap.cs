using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Infrastructure.Mappings;

public class UserArticleMap : NHibernateMap<UserArticle>
{
    public UserArticleMap()
    {
        Map(x => x.UserId);
        Map(x => x.ArticleId);
        Map(x => x.Score);
    }
}