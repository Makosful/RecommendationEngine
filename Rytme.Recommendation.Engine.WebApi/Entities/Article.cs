namespace Rytme.Recommendation.Engine.WebApi.Entities
{
    public record Article
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}