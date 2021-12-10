using Rytme.Recommendation.Engine.WebApi.Data.Interfaces;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

namespace Rytme.Recommendation.Engine.WebApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public IList<Category> GetCategories(IList<AddArticleInput.CategoryScore> categoryIds)
    {
        IList<Category> categories = new List<Category>();
        var queryable = _repository.GetCategoryQuery();

        foreach (var category in queryable)
        {
            var item = queryable.FirstOrDefault(x => x.Id == category.Id);
            if (item is null)
                throw new ArgumentException(""); // TODO
            categories.Add(item);
        }

        return categories;
    }
}