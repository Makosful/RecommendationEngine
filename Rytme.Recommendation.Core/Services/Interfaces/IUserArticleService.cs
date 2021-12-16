using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Core.Services.Interfaces;

public interface IUserArticleService
{
    IList<UserArticle> GetArticlesByUser(long userId);
    IList<UserArticle> GetUsersByArticle(long articleId);
}