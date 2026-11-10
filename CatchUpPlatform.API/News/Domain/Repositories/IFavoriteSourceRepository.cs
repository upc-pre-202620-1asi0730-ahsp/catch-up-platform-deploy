using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.ValueObjects;
using CatchUpPlatform.API.Shared.Domain.Repositories;

namespace CatchUpPlatform.API.News.Domain.Repositories;

/// <summary>
///     The Favorite source repository contract.
/// </summary>
public interface IFavoriteSourceRepository : IBaseRepository<FavoriteSource>
{
    /// <summary>
    ///     Find favorite sources by News API Key
    /// </summary>
    /// <param name="newsApiKey">The News API Key to search.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>
    ///     An Enumerable containing the favorite source objects if found, or empty otherwise.
    /// </returns>
    Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(NewsApiKey newsApiKey,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Find a favorite source by News API Key and Source ID
    /// </summary>
    /// <param name="newsApiKey">The News API Key</param>
    /// <param name="sourceId">The Source ID</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>
    ///     The favorite source object if found, or null otherwise.
    /// </returns>
    Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(NewsApiKey newsApiKey, SourceId sourceId,
        CancellationToken cancellationToken = default);
}