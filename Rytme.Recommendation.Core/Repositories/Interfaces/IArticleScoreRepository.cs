using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Core.Repositories.Interfaces;

public interface IArticleScoreRepository
{
    bool SaveScore(ArticleScore articleScore);
}