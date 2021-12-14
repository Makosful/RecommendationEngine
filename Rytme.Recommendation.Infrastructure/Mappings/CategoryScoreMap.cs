using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Infrastructure.Mappings;

public class CategoryScoreMap : NHibernateMap<UserScore>
{
    public CategoryScoreMap()
    {
        References(x => x.Category);
        Map(x => x.Score);
        Map(x => x.UserId);
    }
}