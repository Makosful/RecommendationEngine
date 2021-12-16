using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Services;
using Rytme.Recommendation.Core.Services.Interfaces;
using Xunit;

namespace Rytme.Recommendation.Core.Test.Services;

public class RecommendationServiceTests
{
    private readonly RecommendationService _sut;
    private readonly IUserArticleService _userArticleService;

    public RecommendationServiceTests()
    {
        _userArticleService = Substitute.For<IUserArticleService>();

        _sut = new RecommendationService(_userArticleService);
    }

    [Fact]
    public void CalculateRecommendation_ShouldReturnGuessedScore_WhenGivenUserAndArticle()
    {
        /* ----------------------
         *     |1  |2  |3  |4   |
         * A   |2.3|   |4.9|4.8 |
         * B   |2.0|2.2|   |??? |
         * C   |   |   |3.0|    |
         * D   |1.7|1.2|   |2.9 |
         * ----------------------
         */

        // Arrange
        // // Mock Data
        UserArticle a1 = new() {Id = 1, ArticleId = 1, UserId = 1, Score = 2.3f, IsAssigned = true, Deleted = false};
        UserArticle a3 = new() {Id = 2, ArticleId = 3, UserId = 1, Score = 4.9f, IsAssigned = true, Deleted = false};
        UserArticle a4 = new() {Id = 3, ArticleId = 4, UserId = 1, Score = 4.8f, IsAssigned = true, Deleted = false};
        UserArticle b1 = new() {Id = 4, ArticleId = 1, UserId = 2, Score = 2.0f, IsAssigned = true, Deleted = false};
        UserArticle b2 = new() {Id = 5, ArticleId = 2, UserId = 2, Score = 2.2f, IsAssigned = true, Deleted = false};
        UserArticle c3 = new() {Id = 6, ArticleId = 3, UserId = 3, Score = 3.0f, IsAssigned = true, Deleted = false};
        UserArticle d1 = new() {Id = 7, ArticleId = 1, UserId = 4, Score = 1.7f, IsAssigned = true, Deleted = false};
        UserArticle d2 = new() {Id = 8, ArticleId = 2, UserId = 4, Score = 1.2f, IsAssigned = true, Deleted = false};
        UserArticle d4 = new() {Id = 9, ArticleId = 4, UserId = 4, Score = 2.9f, IsAssigned = true, Deleted = false};

        // // Expected Collections of Data
        List<UserArticle> userA = new() {a1, a3, a4};
        List<UserArticle> userB = new() {b1, b2};
        List<UserArticle> userC = new() {c3};
        List<UserArticle> userD = new() {d1, d2, d4};
        List<UserArticle> article1 = new() {a1, b1, d1};
        List<UserArticle> article2 = new() {b2, d2};
        List<UserArticle> article3 = new() {a3, c3};
        List<UserArticle> article4 = new() {a4, d4};

        // _userArticleService.GetUsersByArticle(Arg.Any<long>()).Throws<ArgumentException>();
        _userArticleService.GetUsersByArticle(1).Returns(article1);
        _userArticleService.GetUsersByArticle(2).Returns(article2);
        _userArticleService.GetUsersByArticle(3).Returns(article3);
        _userArticleService.GetUsersByArticle(4).Returns(article4);
        // _userArticleService.GetArticlesByUser(Arg.Any<long>()).Throws<ArgumentException>();
        _userArticleService.GetArticlesByUser(1).Returns(userA);
        _userArticleService.GetArticlesByUser(2).Returns(userB);
        _userArticleService.GetArticlesByUser(3).Returns(userC);
        _userArticleService.GetArticlesByUser(4).Returns(userD);

        // Act
        var actual = _sut.CalculateRecommendation(2, 4);

        // Assert
        actual.Should().BeApproximately(3.81, 0.01f);
    }
}