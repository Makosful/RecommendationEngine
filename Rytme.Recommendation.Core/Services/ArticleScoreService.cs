using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Repositories.Interfaces;
using Rytme.Recommendation.Core.Services.Interfaces;

namespace Rytme.Recommendation.Core.Services;

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