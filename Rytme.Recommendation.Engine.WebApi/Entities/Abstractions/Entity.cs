namespace Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;

public abstract class Entity
{
    public virtual long Id { get; set; }

    public virtual bool Deleted { get; set; }
}