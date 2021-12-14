namespace Rytme.Recommendation.WebApi.GraphQL;

/// <summary>
///     This class should define all the services used to implement GraphQL.
///     The purpose of this file is to abstract the implementation from the Startup class, so it can easily be
///     toggled on and off by commenting out one line. This same model should be followed if implementing a
///     traditional REST API.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Add the GraphQL module implementation to the Service Collection.
    /// </summary>
    /// <param name="services"></param>
    public static void AddGraphQlServices(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<Query>() // Query functionality
            .AddMutationType<Mutation>(); // Add/change functionality
    }
}