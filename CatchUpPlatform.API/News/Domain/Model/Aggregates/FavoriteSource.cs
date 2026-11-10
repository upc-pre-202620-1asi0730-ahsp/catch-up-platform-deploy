using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Domain.Model.ValueObjects;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

/// <summary>
///     Represents a favorite news source for a given News API key.
/// </summary>
/// <remarks>
///     This aggregate root represents a user's favorite news source.
///     The combination of (NewsApiKey, SourceId) must be unique within the system.
///     Instances are immutable after creation; updates are handled through commands.
///     Audit timestamps (CreatedDate, UpdatedDate) are managed by the persistence layer.
/// </remarks>
public partial class FavoriteSource
{
    /// <summary>
    ///     Protected parameterless constructor for EF Core.
    /// </summary>
    protected FavoriteSource()
    {
        NewsApiKey = null!;
        SourceId = null!;
    }

    /// <summary>
    ///     Creates a new FavoriteSource from a creation command.
    /// </summary>
    /// <remarks>
    ///     This constructor acts as the command handler for CreateFavoriteSourceCommand.
    ///     It initializes the aggregate with the required NewsApiKey and SourceId.
    /// </remarks>
    /// <param name="command">The CreateFavoriteSourceCommand command</param>
    /// <exception cref="ArgumentNullException">Thrown when command is null.</exception>
    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        NewsApiKey = command.NewsApiKey;
        SourceId = command.SourceId;
    }

    /// <summary>
    ///     Gets the server-generated identifier for this favorite source.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    ///     Gets the News API key associated with this favorite source.
    /// </summary>
    public NewsApiKey NewsApiKey { get; private set; }
    
    /// <summary>
    ///     Gets the source identifier from the News API.
    /// </summary>
    public SourceId SourceId { get; private set; }
}