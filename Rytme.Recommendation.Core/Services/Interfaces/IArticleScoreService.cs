using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Core.Services.Interfaces;

public interface IArticleScoreService
{
    bool AddScore(ArticleScore articleScore);
}