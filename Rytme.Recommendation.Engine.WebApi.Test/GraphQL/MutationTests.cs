using System;
using FluentAssertions;
using HotChocolate.Execution;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Rytme.Recommendation.Engine.WebApi.Data;
using Rytme.Recommendation.Engine.WebApi.GraphQL;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Xunit;

namespace Rytme.Recommendation.Engine.WebApi.Test.GraphQL
{
    public class MutationTests
    {
        private readonly IArticleRepository _repository;
        private readonly Mutation _sut; // System Under Testing

        public MutationTests()
        {
            _repository = Substitute.For<IArticleRepository>();

            _sut = new Mutation(_repository);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void AddArticle_ShouldReturnError_WhenInputIsEmptyOrWhitespace(string input)
        {
            // Arrange
            const string errMsg = "Input is empty";
            AddArticleInput articleInput = new(1, input);

            // Act
            Action action = () => _sut.AddArticle(articleInput);

            // Assert
            action.Should().Throw<QueryException>().WithMessage(errMsg);
        }

        [Fact]
        public void AddArticle_ShouldReturnError_WhenRepositoryReturnsNull()
        {
            // Arrange
            const string errMsg = "Article already exists";
            AddArticleInput input = new(123456789, "One For All");
            _repository.AddArticle(Arg.Any<AddArticleInput>())
                .Throws(new ArgumentException(errMsg));

            // Act
            Action action = () => _sut.AddArticle(input);

            // Assert
            action.Should().Throw<QueryException>().WithMessage(errMsg);
        }
    }
}