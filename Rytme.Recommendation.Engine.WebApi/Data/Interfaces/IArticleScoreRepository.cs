using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Interfaces;

public interface IArticleScoreRepository
{
    bool SaveScore(ArticleScore articleScore);
}