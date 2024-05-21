using System;
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

    [Theory]
    [InlineData(01, 01, 2.0)]
    [InlineData(01, 06, 2.0)]
    [InlineData(01, 09, 3.4)]
    [InlineData(02, 01, 2.5)]
    [InlineData(02, 02, 2.9)]
    [InlineData(02, 05, 2.8)]
    [InlineData(03, 01, 2.7)]
    [InlineData(03, 03, 2.3)]
    [InlineData(03, 07, 2.8)]
    [InlineData(04, 01, 2.4)]
    [InlineData(04, 04, 2.9)]
    [InlineData(04, 05, 2.5)]
    [InlineData(04, 06, 1.7)]
    [InlineData(04, 09, 3.1)]
    [InlineData(05, 05, 2.8)]
    [InlineData(05, 06, 2.0)]
    [InlineData(05, 09, 3.7)]
    [InlineData(05, 10, 2.7)]
    [InlineData(06, 02, 2.7)]
    [InlineData(06, 06, 1.9)]
    [InlineData(06, 08, 2.6)]
    [InlineData(06, 09, 3.3)]
    [InlineData(07, 02, 2.6)]
    [InlineData(07, 04, 3.0)]
    [InlineData(07, 06, 2.1)]
    [InlineData(07, 07, 2.6)]
    [InlineData(07, 08, 2.5)]
    [InlineData(08, 02, 2.8)]
    [InlineData(08, 03, 2.3)]
    [InlineData(08, 05, 2.8)]
    [InlineData(08, 06, 1.9)]
    [InlineData(08, 08, 2.7)]
    [InlineData(08, 09, 3.8)]
    [InlineData(09, 02, 3.0)]
    [InlineData(09, 03, 3.0)]
    [InlineData(09, 04, 3.3)]
    [InlineData(09, 05, 3.0)]
    [InlineData(09, 06, 4.0)]
    [InlineData(09, 07, 3.3)]
    [InlineData(09, 08, 2.0)]
    [InlineData(09, 09, 4.5)]
    [InlineData(09, 10, 3.0)]
    public void CalculateRecommendation_ShouldReturnGuessedScore_WhenGivenUserAndArticle(
        long userId,
        long articleId,
        double expected)
    {
        // Arrange
        var id = 0;
        UserArticle user1Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 1,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 1,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 1,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 1,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 2,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 2,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 2,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 2,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 3,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 3,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 3,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 3,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 4,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 4,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 4,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 4,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 4,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 5,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 5,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 5,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 6,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 6,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 6,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 6,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 6,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 6,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 7,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 7,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 7,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 7,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 7,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 8,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 8,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 8,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 8,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user9Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 9,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 10,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 10,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 10,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 10,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 10,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 10,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };

        _userArticleService.GetUsersByArticle(1).Returns(new List<UserArticle>
        {
            user5Article1,
            user6Article1,
            user7Article1,
            user8Article1,
            user9Article1,
            user10Article1
        });
        _userArticleService.GetUsersByArticle(2).Returns(new List<UserArticle>
        {
            user1Article2,
            user3Article2,
            user4Article2,
            user5Article2,
            user10Article2
        });
        _userArticleService.GetUsersByArticle(3).Returns(new List<UserArticle>
        {
            user1Article3,
            user2Article3,
            user4Article3,
            user5Article3,
            user6Article3,
            user7Article3,
            user10Article3
        });
        _userArticleService.GetUsersByArticle(4).Returns(new List<UserArticle>
        {
            user1Article4,
            user2Article4,
            user3Article4,
            user5Article4,
            user6Article4,
            user8Article4,
            user10Article4
        });
        _userArticleService.GetUsersByArticle(5).Returns(new List<UserArticle>
        {
            user1Article5,
            user3Article5,
            user6Article5,
            user7Article5,
            user10Article5
        });
        _userArticleService.GetUsersByArticle(6).Returns(new List<UserArticle>
        {
            user2Article6,
            user3Article6,
            user10Article6
        });
        _userArticleService.GetUsersByArticle(7).Returns(new List<UserArticle>
        {
            user1Article7,
            user2Article7,
            user4Article7,
            user5Article7,
            user6Article7,
            user8Article7,
            user10Article7
        });
        _userArticleService.GetUsersByArticle(8).Returns(new List<UserArticle>
        {
            user1Article8,
            user2Article8,
            user3Article8,
            user4Article8,
            user5Article8,
            user10Article8
        });
        _userArticleService.GetUsersByArticle(9).Returns(new List<UserArticle>
        {
            user2Article9,
            user3Article9,
            user7Article9,
            user10Article9
        });
        _userArticleService.GetUsersByArticle(10).Returns(new List<UserArticle>
        {
            user1Article10,
            user2Article10,
            user3Article10,
            user4Article10,
            user6Article10,
            user7Article10,
            user8Article10,
            user10Article10
        });
        _userArticleService.GetArticlesByUser(1).Returns(new List<UserArticle>
        {
            user1Article2,
            user1Article3,
            user1Article4,
            user1Article5,
            user1Article7,
            user1Article8,
            user1Article10
        });
        _userArticleService.GetArticlesByUser(2).Returns(new List<UserArticle>
        {
            user2Article3,
            user2Article4,
            user2Article6,
            user2Article7,
            user2Article8,
            user2Article9,
            user2Article10
        });
        _userArticleService.GetArticlesByUser(3).Returns(new List<UserArticle>
        {
            user3Article2,
            user3Article4,
            user3Article5,
            user3Article6,
            user3Article8,
            user3Article9,
            user3Article10
        });
        _userArticleService.GetArticlesByUser(4).Returns(new List<UserArticle>
        {
            user4Article2,
            user4Article3,
            user4Article7,
            user4Article8,
            user4Article10
        });
        _userArticleService.GetArticlesByUser(5).Returns(new List<UserArticle>
        {
            user5Article1,
            user5Article2,
            user5Article3,
            user5Article4,
            user5Article7,
            user5Article8
        });
        _userArticleService.GetArticlesByUser(6).Returns(new List<UserArticle>
        {
            user6Article1,
            user6Article3,
            user6Article4,
            user6Article5,
            user6Article7,
            user6Article10
        });
        _userArticleService.GetArticlesByUser(7).Returns(new List<UserArticle>
        {
            user7Article1,
            user7Article3,
            user7Article5,
            user7Article9,
            user7Article10
        });
        _userArticleService.GetArticlesByUser(8).Returns(new List<UserArticle>
        {
            user8Article1,
            user8Article4,
            user8Article7,
            user8Article10
        });
        _userArticleService.GetArticlesByUser(9).Returns(new List<UserArticle>
        {
            user9Article1
        });
        _userArticleService.GetArticlesByUser(10).Returns(new List<UserArticle>
        {
            user10Article1,
            user10Article2,
            user10Article3,
            user10Article4,
            user10Article5,
            user10Article6,
            user10Article7,
            user10Article8,
            user10Article9,
            user10Article10
        });

        // Act
        var actual = _sut.CalculateRecommendation(userId, articleId);

        // Assert
        actual.Should().BeApproximately(expected, 0.09f);
    }

    [Theory]
    [InlineData(01)] // Min
    [InlineData(02)] // Min + 1
    [InlineData(05)] // Nominal
    [InlineData(09)] // Max - 1
    [InlineData(10)] // Max
    public void CalculateRecommendation_ShouldAcceptUserIdInRange(long userId)
    {
        // Arrange
        // // Mock Data
        var id = 0;
        UserArticle user1Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 1,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 1,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 1,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 1,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user1Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 1,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 2,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 2,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 2,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 2,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user2Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 2,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 3,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 3,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 3,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 3,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user3Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 3,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 4,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 4,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 4,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 4,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user4Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 4,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 5,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 5,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 5,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user5Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 5,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 6,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 6,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 6,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 6,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 6,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user6Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 6,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 7,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 7,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 7,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 7,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user7Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 7,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 8,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 8,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 8,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user8Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 8,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user9Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 9,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article1 = new()
        {
            Id = ++id,
            ArticleId = 1,
            UserId = 10,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article2 = new()
        {
            Id = ++id,
            ArticleId = 2,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article3 = new()
        {
            Id = ++id,
            ArticleId = 3,
            UserId = 10,
            Score = 2f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article4 = new()
        {
            Id = ++id,
            ArticleId = 4,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article5 = new()
        {
            Id = ++id,
            ArticleId = 5,
            UserId = 10,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article6 = new()
        {
            Id = ++id,
            ArticleId = 6,
            UserId = 10,
            Score = 4f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article7 = new()
        {
            Id = ++id,
            ArticleId = 7,
            UserId = 10,
            Score = 1f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article8 = new()
        {
            Id = ++id,
            ArticleId = 8,
            UserId = 10,
            Score = 3f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article9 = new()
        {
            Id = ++id,
            ArticleId = 9,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };
        UserArticle user10Article10 = new()
        {
            Id = ++id,
            ArticleId = 10,
            UserId = 10,
            Score = 5f,
            IsAssigned = true,
            Deleted = false
        };

        _userArticleService.GetUsersByArticle(1).Returns(new List<UserArticle>
        {
            user5Article1,
            user6Article1,
            user7Article1,
            user8Article1,
            user9Article1,
            user10Article1
        });
        _userArticleService.GetUsersByArticle(2).Returns(new List<UserArticle>
        {
            user1Article2,
            user3Article2,
            user4Article2,
            user5Article2,
            user10Article2
        });
        _userArticleService.GetUsersByArticle(3).Returns(new List<UserArticle>
        {
            user1Article3,
            user2Article3,
            user4Article3,
            user5Article3,
            user6Article3,
            user7Article3,
            user10Article3
        });
        _userArticleService.GetUsersByArticle(4).Returns(new List<UserArticle>
        {
            user1Article4,
            user2Article4,
            user3Article4,
            user5Article4,
            user6Article4,
            user8Article4,
            user10Article4
        });
        _userArticleService.GetUsersByArticle(5).Returns(new List<UserArticle>
        {
            user1Article5,
            user3Article5,
            user6Article5,
            user7Article5,
            user10Article5
        });
        _userArticleService.GetUsersByArticle(6).Returns(new List<UserArticle>
        {
            user2Article6,
            user3Article6,
            user10Article6
        });
        _userArticleService.GetUsersByArticle(7).Returns(new List<UserArticle>
        {
            user1Article7,
            user2Article7,
            user4Article7,
            user5Article7,
            user6Article7,
            user8Article7,
            user10Article7
        });
        _userArticleService.GetUsersByArticle(8).Returns(new List<UserArticle>
        {
            user1Article8,
            user2Article8,
            user3Article8,
            user4Article8,
            user5Article8,
            user10Article8
        });
        _userArticleService.GetUsersByArticle(9).Returns(new List<UserArticle>
        {
            user2Article9,
            user3Article9,
            user7Article9,
            user10Article9
        });
        _userArticleService.GetUsersByArticle(10).Returns(new List<UserArticle>
        {
            user1Article10,
            user2Article10,
            user3Article10,
            user4Article10,
            user6Article10,
            user7Article10,
            user8Article10,
            user10Article10
        });
        _userArticleService.GetArticlesByUser(1).Returns(new List<UserArticle>
        {
            user1Article2,
            user1Article3,
            user1Article4,
            user1Article5,
            user1Article7,
            user1Article8,
            user1Article10
        });
        _userArticleService.GetArticlesByUser(2).Returns(new List<UserArticle>
        {
            user2Article3,
            user2Article4,
            user2Article6,
            user2Article7,
            user2Article8,
            user2Article9,
            user2Article10
        });
        _userArticleService.GetArticlesByUser(3).Returns(new List<UserArticle>
        {
            user3Article2,
            user3Article4,
            user3Article5,
            user3Article6,
            user3Article8,
            user3Article9,
            user3Article10
        });
        _userArticleService.GetArticlesByUser(4).Returns(new List<UserArticle>
        {
            user4Article2,
            user4Article3,
            user4Article7,
            user4Article8,
            user4Article10
        });
        _userArticleService.GetArticlesByUser(5).Returns(new List<UserArticle>
        {
            user5Article1,
            user5Article2,
            user5Article3,
            user5Article4,
            user5Article7,
            user5Article8
        });
        _userArticleService.GetArticlesByUser(6).Returns(new List<UserArticle>
        {
            user6Article1,
            user6Article3,
            user6Article4,
            user6Article5,
            user6Article7,
            user6Article10
        });
        _userArticleService.GetArticlesByUser(7).Returns(new List<UserArticle>
        {
            user7Article1,
            user7Article3,
            user7Article5,
            user7Article9,
            user7Article10
        });
        _userArticleService.GetArticlesByUser(8).Returns(new List<UserArticle>
        {
            user8Article1,
            user8Article4,
            user8Article7,
            user8Article10
        });
        _userArticleService.GetArticlesByUser(9).Returns(new List<UserArticle>
        {
            user9Article1
        });
        _userArticleService.GetArticlesByUser(10).Returns(new List<UserArticle>
        {
            user10Article1,
            user10Article2,
            user10Article3,
            user10Article4,
            user10Article5,
            user10Article6,
            user10Article7,
            user10Article8,
            user10Article9,
            user10Article10
        });
        
        // Act
        Action action = () => _sut.CalculateRecommendation(userId, 1);
        
        // Assert
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(00)] // Min - 1
    [InlineData(-1)]
    [InlineData(-5)]
    public void CalculateRecommendation_ShouldThrowArgumentException_WhenUserIdIsNegative(long id)
    {
        // Arrange
        // Nothing special
        
        // Act
        Action action = () => _sut.CalculateRecommendation(id, 1);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(00)] // Min - 1
    [InlineData(-1)]
    [InlineData(-5)]
    public void CalculateRecommendation_ShouldThrowArgumentException_WhenArticleIdIsNegative(long id)
    {
        // Arrange
        // Nothing special
        
        // Act
        Action action = () => _sut.CalculateRecommendation(1, id);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(00)] // Min - 1
    [InlineData(-1)]
    [InlineData(-5)]
    public void CalculateRecommendation_ShouldThrowArgumentException_WhenUserDoesNotExist(long id)
    {
        // Arrange
        _userArticleService.GetArticlesByUser(Arg.Any<long>()).Returns(new List<UserArticle>()); // Return empty
        
        // Act
        Action action = () => _sut.CalculateRecommendation(id, 1);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(00)] // Min - 1
    [InlineData(-1)]
    [InlineData(-5)]
    public void CalculateRecommendation_ShouldThrowArgumentException_WhenArticleDoesNotExist(long id)
    {
        // Arrange
        _userArticleService.GetUsersByArticle(Arg.Any<long>()).Returns(new List<UserArticle>()); // Return empty
        
        // Act
        Action action = () => _sut.CalculateRecommendation(1, id);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}