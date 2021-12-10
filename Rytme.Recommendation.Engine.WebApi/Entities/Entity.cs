namespace Rytme.Recommendation.Engine.WebApi.Entities;

public abstract class Entity
{
    public long Id { get; set; }

    public bool Deleted { get; set; }
}