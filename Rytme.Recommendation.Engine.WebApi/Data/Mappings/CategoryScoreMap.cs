using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Mappings;

public class CategoryScoreMap : NHibernateMap<UserScore>
{
    public CategoryScoreMap()
    {
        References(x => x.Category);
        Map(x => x.Score);
        Map(x => x.UserId);
    }
}