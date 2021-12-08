namespace Rytme.Recommendation.Engine.WebApi.Entities
{
    public record Article
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}