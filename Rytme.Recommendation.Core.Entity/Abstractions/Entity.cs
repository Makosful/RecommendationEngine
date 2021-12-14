namespace Rytme.Recommendation.Core.Entity.Abstractions;

public abstract class Entity
{
    public virtual long Id { get; set; }

    public virtual bool Deleted { get; set; }
}