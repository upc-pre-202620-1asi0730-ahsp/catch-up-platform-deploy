using CatchUpPlatform.API.Shared.Domain.Model;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

/// <summary>
///     Audit extension for FavoriteSource aggregate.
/// </summary>
/// <remarks>
///     This partial class extends FavoriteSource with audit trail properties.
///     CreatedAt and UpdatedAt are automatically managed by the persistence layer
///     via the AuditableEntityInterceptor in the Shared bounded context.
///     Implements the IAuditableEntity interface to provide these properties.
/// </remarks>
public partial class FavoriteSource : IAuditableEntity
{
    /// <summary>
    ///     Gets the timestamp when this favorite source was created.
    /// </summary>
    /// <remarks>
    ///     Automatically set once by the persistence layer on first insert. Maps to column: created_at.
    /// </remarks>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    ///     Gets the timestamp when this favorite source was last updated.
    /// </summary>
    /// <remarks>
    ///     Automatically refreshed by the persistence layer on every save. Maps to column: updated_at.
    /// </remarks>
    public DateTimeOffset? UpdatedAt { get; set; }
}