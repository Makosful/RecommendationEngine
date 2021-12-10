using Rytme.Recommendation.Engine.WebApi.Data.Base;
using Rytme.Recommendation.Engine.WebApi.Data.Interfaces;
using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data;

public class ArticleScoreRepository : NhRepository<ArticleScore>, IArticleScoreRepository
{
    public bool SaveScore(ArticleScore articleScore)
    {
        var isSaved = SaveOrUpdate(articleScore);
        return isSaved;
    }
}