namespace Rytme.Recommendation.Core;

public static class Algorithms
{
    /// <summary>
    ///     Determine the similarity between two vector sets.
    ///     Note, it's important that the two vector sets are equally long and already ordered
    /// </summary>
    /// <param name="vectorA"></param>
    /// <param name="vectorB"></param>
    /// <returns>
    ///     Returns a number between 0 and 1, in indicating how similar the two vector sets are. Higher = more alike.
    /// </returns>
    public static double CosineSimilarity(double[] vectorA, double[] vectorB)
    {
        // (A * B) / ( ||A|| * ||B|| )

        // |A| == |B|
        if (vectorA.Length != vectorB.Length)
            throw new ArgumentException("Thw two vector sets are of different length");

        // A * B
        double dividend = 0f;
        for (var i = 0; i < vectorA.Length; i++)
        {
            var a = vectorA[i];
            var b = vectorB[i];
            var c = a * b;
            dividend += c;
        }

        // ||A|| * ||B||
        double d = 0f;
        foreach (var x in vectorA) d += (float) Math.Pow(x, 2);
        double e = 0f;
        foreach (var x in vectorB) e += (float) Math.Pow(x, 2);
        var denominator = Math.Sqrt(d) * Math.Sqrt(e);

        return dividend / denominator;
    }
}