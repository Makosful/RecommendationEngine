using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Rytme.Recommendation.Engine.WebApi.Data;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL;
using Xunit;

namespace Rytme.Recommendation.Engine.WebApi.Test.GraphQL
{
    public class QueryTests
    {
        private readonly CancellationToken _cancellation;
        private readonly IArticleRepository _repository;
        private readonly Query _sut; // System Under Testing

        public QueryTests()
        {
            CancellationTokenSource tokenSource = new();
            _cancellation = tokenSource.Token;

            _repository = Substitute.For<IArticleRepository>();

            _sut = new Query(_repository);
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange
            IEnumerable<Article> expected = new List<Article>
            {
                new()
                {
                    Id = 123456789,
                    Title = "The Art of Not Giving a Fuck"
                },
                new()
                {
                    Id = 234567891,
                    Title = "12 Rules for Life"
                }
            };
            _repository.GetAllArticles().Returns(expected);

            // Act
            IEnumerable<Article> actual = await _sut.GetArticles(_cancellation);

            // Assert
            actual.Should().NotBeNull("{0} should return empty list if none exists",
                nameof(IArticleRepository.GetArticles));
        }
    }
}