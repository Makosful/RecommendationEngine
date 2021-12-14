namespace Rytme.Recommendation.Core.Entity;

public class UserScore : Abstractions.Entity
{
    public virtual float Score { get; set; }

    public virtual long UserId { get; set; }

    public virtual Category Category { get; set; }
}