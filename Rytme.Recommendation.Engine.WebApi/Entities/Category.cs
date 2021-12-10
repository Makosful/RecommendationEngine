using Rytme.Recommendation.Engine.WebApi.Entities.Abstractions;

namespace Rytme.Recommendation.Engine.WebApi.Entities;

public class Category : Entity
{
    public virtual string Name { get; set; }
}