using Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;

namespace Rytme.Recommendation.Engine.WebApi.Entities;

public class UserArticle : Entity
{
    public virtual long UserId { get; set; }

    public virtual long ArticleId { get; set; }

    public virtual float Score { get; set; }
}