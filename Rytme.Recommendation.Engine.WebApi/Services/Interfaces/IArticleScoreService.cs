using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

public interface IArticleScoreService
{
    bool AddScore(ArticleScore articleScore);
}