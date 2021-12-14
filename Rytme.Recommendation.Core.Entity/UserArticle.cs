namespace Rytme.Recommendation.Core.Entity;

public class UserArticle : Abstractions.Entity
{
    public virtual long UserId { get; set; }

    public virtual long ArticleId { get; set; }

    public virtual float Score { get; set; }
}