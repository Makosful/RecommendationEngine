using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

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