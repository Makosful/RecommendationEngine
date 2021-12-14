using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Infrastructure.Mappings;

public class ArticleScoreMap : NHibernateMap<ArticleScore>
{
    public ArticleScoreMap()
    {
        References(x => x.Category);
        Map(x => x.ArticleId);
        Map(x => x.Score);
        Map(x => x.IsAssigned);
    }
}