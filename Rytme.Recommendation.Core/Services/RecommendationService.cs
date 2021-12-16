using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Services.Interfaces;

namespace Rytme.Recommendation.Core.Services;

public class RecommendationService
{
    private readonly IUserArticleService _userScoreService;

    public RecommendationService(IUserArticleService userScoreService)
    {
        _userScoreService = userScoreService;
    }

    public double CalculateRecommendation(long userId, long articleId)
    {
        var desiredUserArticles = _userScoreService.GetArticlesByUser(userId);
        var usersThatHaveReadTheArticle = _userScoreService.GetUsersByArticle(articleId);

        var score = 0d;

        foreach (var user in usersThatHaveReadTheArticle)
        {
            IList<UserArticle> currentUserFilteredList = new List<UserArticle>();
            IList<UserArticle> desiredUserFilteredList = new List<UserArticle>();
            UserArticle? exactArticle = null;

            var allArticlesFromCurrentUser = _userScoreService.GetArticlesByUser(user.UserId);

            foreach (var desiredUserArticle in desiredUserArticles) // Go through all the main user's articles
            foreach (var currentUserArticle in allArticlesFromCurrentUser) // Go through all this users articles
            {
                // If the current article is the same as the main article, save it for later
                if (currentUserArticle.ArticleId == articleId) exactArticle = currentUserArticle;

                // If the desired and current articles to not match, move on to the next pair
                if (desiredUserArticle.ArticleId != currentUserArticle.ArticleId) continue;

                desiredUserFilteredList.Add(desiredUserArticle);
                currentUserFilteredList.Add(currentUserArticle);
            }

            if (exactArticle is null) // This shouldn't really happen, but might as well be safe
                throw new InvalidOperationException($"Variable {nameof(exactArticle)} was never set");

            var vectorA = currentUserFilteredList.Select(x => x.Score).ToArray();
            var vectorB = desiredUserFilteredList.Select(x => x.Score).ToArray();

            var similarity = Algorithms.CosineSimilarity(vectorA, vectorB);
            var weightedScore = exactArticle!.Score * similarity;
            score += weightedScore;
        }

        return score / usersThatHaveReadTheArticle.Count;
    }
}