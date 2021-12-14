using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Repositories.Interfaces;
using Rytme.Recommendation.Infrastructure.Base;

namespace Rytme.Recommendation.Infrastructure;

public class ArticleScoreRepository : NhRepository<ArticleScore>, IArticleScoreRepository
{
    public bool SaveScore(ArticleScore articleScore)
    {
        var isSaved = SaveOrUpdate(articleScore);
        return isSaved;
    }
}