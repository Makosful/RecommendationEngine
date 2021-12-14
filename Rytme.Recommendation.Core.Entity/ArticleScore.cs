namespace Rytme.Recommendation.Core.Entity;

public class ArticleScore : Abstractions.Entity
{
    public virtual long ArticleId { get; set; }

    public virtual Category Category { get; set; }

    public virtual float Score { get; set; }

    /// <summary>
    ///     Indicates whether or not the Score is assigned or guessed
    /// </summary>
    public virtual bool IsAssigned { get; set; }
}