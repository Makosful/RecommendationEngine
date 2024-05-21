using System;
using FluentAssertions;
using Xunit;

namespace Rytme.Recommendation.Core.Test;

public class AlgorithmTests
{
    /// <summary>
    ///     Boundary Test: |Vector| = 0
    /// </summary>
    [Fact]
    public void CosineSimilarity_ShouldThrowArgumentException_IfVectorsContainNoElements()
    {
        // Arrange
        double[] vector1 = { };
        double[] vector2 = { };

        // Act
        Action action = () => Algorithms.CosineSimilarity(vector1, vector2);

        // Assert
        action.Should().Throw<ArgumentException>("because empty vectors have no data to work with");
    }

    [Theory]
    [InlineData(new[] {1d, 1d, 1d, 2d, 2d, 1d, 0d, 0d, 0d, 0d}, new[] {0d, 1d, 0d, 2d, 2d, 0d, 1d, 0d, 0d})]
    [InlineData(new[] {0d, 1d, 0d, 2d, 2d, 0d, 1d, 0d, 0d}, new[] {1d, 1d, 1d, 2d, 2d, 1d, 0d, 0d, 0d, 0d})]
    [InlineData(new[] {1d}, new[] {0d, 1d})]
    [InlineData(new[] {0d, 1d}, new[] {1d})]
    public void CosineSimilarity_ShouldThrowArgumentException_WhenInputVectorsAreNotEquallyLong(
        double[] v1, double[] v2)
    {
        // Arrange
        // N/A

        // Act
        Action action = () => Algorithms.CosineSimilarity(v1, v2);

        // Assert
        action.Should().Throw<ArgumentException>("because input vectors are not the same length");
    }

    [Theory]
    [InlineData(
        new[] {1d, 1d, 1d, 2d, 2d, 1d, 0d, 0d, 0d, 0d}, // Length = 10, Index = 9
        new[] {0d, 1d, 0d, 2d, 2d, 0d, 1d, 0d, 0d, 0d}, // Length = 10, Index = 9
        0.82d)]
    [InlineData(
        new[] {2.0d, 2.2d}, // User B
        new[] {1.7d, 1.2d}, // User D
        0.98d)]
    [InlineData(
        new[] {2.0d}, // User B
        new[] {2.3d}, // User A
        1.00d)]
    public void CosineSimilarity_ShouldReturnExpected(double[] v1, double[] v2, double expected)
    {
        // Arrange

        // Act
        var actual = Algorithms.CosineSimilarity(v1, v2);

        // Assert
        actual.Should().BeApproximately(expected, 0.01f);
    }
}