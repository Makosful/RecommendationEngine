using Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;

namespace Rytme.Recommendation.Engine.WebApi.Entities;

public class UserScore : Entity
{
    public virtual float Score { get; set; }

    public virtual long UserId { get; set; }

    public virtual Category Category { get; set; }
}