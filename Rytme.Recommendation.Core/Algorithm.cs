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
        if (vectorA.Length != vectorB.Length)
            throw new ArgumentException("The two vector sets are of different length");
        if (vectorA.Length < 1)
            throw new ArgumentException("Vectors must contain at least 1 item");

        // { n≥0; dividend = { (A[0:n-1] * B[0:n-1]) }
        // Sum(∀i∈A: A[i] * B[i])
        // { dividend = { (A[0] * B[0]) + (A[1] * B[1]) + ... + (A[i] * B[i])} }
        double dividend = 0f;
        for (var i = 0; i < vectorA.Length; i++) 
            dividend += vectorA[i] * vectorB[i];
        
        // Invariant
        // 0 ≤ d; dₙ ≥ dₙ₋₁
        // Initialization
        // d = 0;
        double d = 0f;
        for (var i = 0; i < vectorA.Length; i++) 
            // Maintenance
            // Assuming N = i-1 ^ N >= 0;
            // d will be the sum of each vector in A lifted to the power of 2, up until N
            // ∀x∈A: 0 < x < i: Sum(Pow(x)) 
            d += (float) Math.Pow(vectorA[i], 2);
            // Termination
            // i will continue to increment by 1.
            // vectorA.Length will remain unchanged.
            // i will eventually become equal or grater than vectorA.Length, which terminates the loop

        double e = 0f;
        for (var i = 0; i < vectorB.Length; i++) 
            e += (float) Math.Pow(vectorB[i], 2);

        var denominator = Math.Sqrt(d) * Math.Sqrt(e);

        return dividend / denominator;
    }
}