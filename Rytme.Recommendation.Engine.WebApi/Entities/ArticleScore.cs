using Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;

namespace Rytme.Recommendation.Engine.WebApi.Entities;

public class ArticleScore : Entity
{
    public virtual long ArticleId { get; set; }

    public virtual Category Category { get; set; }

    public virtual float Score { get; set; }

    /// <summary>
    ///     Indicates whether or not the Score is assigned or guessed
    /// </summary>
    public virtual bool IsAssigned { get; set; }
}