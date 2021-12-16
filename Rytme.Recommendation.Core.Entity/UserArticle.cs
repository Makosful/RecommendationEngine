namespace Rytme.Recommendation.Core.Entity;

public class UserArticle : Abstractions.Entity
{
    public virtual long UserId { get; set; }

    public virtual long ArticleId { get; set; }

    public virtual double Score { get; set; }

    /// <summary>
    ///     Indicates whether the score has been assigned manually.
    ///     Scores guessed by the system should not overwrite the score
    ///     observed from the user's interaction with the article.
    /// </summary>
    public virtual bool IsAssigned { get; set; }
}