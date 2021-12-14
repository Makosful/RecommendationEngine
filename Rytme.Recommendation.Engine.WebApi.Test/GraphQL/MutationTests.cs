using System;
using System.Collections.Generic;
using FluentAssertions;
using HotChocolate.Execution;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;
using Xunit;

namespace Rytme.Recommendation.Engine.WebApi.Test.GraphQL;

public class MutationTests
{
    private readonly ICategoryService _categoryService;
    private readonly IArticleScoreService _scoreService;
    private readonly Mutation _sut; // System Under Test

    // Global Arrange
    public MutationTests()
    {
        _scoreService = Substitute.For<IArticleScoreService>();
        _categoryService = Substitute.For<ICategoryService>();

        _sut = new Mutation();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void AddArticle_ShouldThrowQueryException_WhenArticleIdIsZeroOrNegative(int id)
    {
        // Arrange
        var addArticleInput = new AddArticleInput
        {
            Id = id,
            Categories = new List<CategoryScore>
            {
                new() {Id = 123456789, Score = 5f}
            }
        };

        // Act
        Action action = () => _sut.AddArticle(_scoreService, _categoryService, addArticleInput);

        // Assert
        action.Should().Throw<QueryException>();
    }

    [Fact]
    public void AddArticle_ShouldCallIArticleScoreServiceOnce()
    {
        // Arrange
        _categoryService
            .GetCategories(Arg.Any<IList<CategoryScore>>())
            .Returns(new List<Category>
            {
                new() {Id = 1, Deleted = false, Name = "Foo"},
                new() {Id = 2, Deleted = false, Name = "Bar"},
                new() {Id = 3, Deleted = false, Name = "Yar"}
            });
        _scoreService.AddScore(Arg.Any<ArticleScore>()).Returns(true);
        var input = new AddArticleInput
        {
            Id = 123456789,
            Categories = new List<CategoryScore>
            {
                new()
                {
                    Id = 3,
                    Score = 5.0f
                }
            }
        };

        // Act
        _sut.AddArticle(_scoreService, _categoryService, input);

        // Assert
        _scoreService.Received(1).AddScore(Arg.Any<ArticleScore>());
    }

    [Fact]
    public void AddArticle_ShouldThrowQueryException_WhenCategoryServiceFails()
    {
        // Arrange
        _categoryService
            .GetCategories(Arg.Any<IList<CategoryScore>>())
            .Throws(new Exception());
        var input = new AddArticleInput
        {
            Id = 1,
            Categories = new List<CategoryScore>()
        };

        // Act
        Action action = () => _sut.AddArticle(_scoreService, _categoryService, input);

        // Assert
        action.Should().Throw<QueryException>();
    }
}