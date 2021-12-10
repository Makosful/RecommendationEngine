using Rytme.Recommendation.Engine.WebApi.Data.Interfaces;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

namespace Rytme.Recommendation.Engine.WebApi.Services;

public class ArticleScoreService : IArticleScoreService
{
    private readonly IArticleScoreRepository _repository;

    public ArticleScoreService(IArticleScoreRepository repository)
    {
        _repository = repository;
    }

    public bool AddScore(ArticleScore articleScore)
    {
        var isSaved = _repository.SaveScore(articleScore);
        return isSaved;
    }
}