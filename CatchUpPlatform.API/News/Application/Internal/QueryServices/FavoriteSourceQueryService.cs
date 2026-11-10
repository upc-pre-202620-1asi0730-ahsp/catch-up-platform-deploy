using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Application.Services;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Repositories;

namespace CatchUpPlatform.API.News.Application.Internal.QueryServices;

/// <summary>
///     Application service for querying favorite sources.
/// </summary>
/// <remarks>
///     This service acts as the query handler for retrieving favorite sources.
///     It supports queries by NewsApiKey, by ID, and by the composite key (NewsApiKey + SourceId).
///     All queries delegate to the repository layer for data access.
/// </remarks>
/// <param name="favoriteSourceRepository">Repository for accessing favorite source data.</param>
public class FavoriteSourceQueryService(IFavoriteSourceRepository favoriteSourceRepository)
    : IFavoriteSourceQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query,
        CancellationToken cancellationToken = default) =>
        await favoriteSourceRepository.FindByNewsApiKeyAsync(query.NewsApiKey, cancellationToken);

    /// <inheritdoc />
    public async Task<FavoriteSource?> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query,
        CancellationToken cancellationToken = default) =>
        await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(query.NewsApiKey, query.SourceId,
            cancellationToken);

    /// <inheritdoc />
    public async Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query,
        CancellationToken cancellationToken = default) =>
        await favoriteSourceRepository.FindByIdAsync(query.Id, cancellationToken);
}