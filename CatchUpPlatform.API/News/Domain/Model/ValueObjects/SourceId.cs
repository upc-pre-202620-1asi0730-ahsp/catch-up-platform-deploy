namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

/// <summary>
///     Value object representing a validated source identifier.
/// </summary>
public sealed record SourceId
{
    private const int MaxLength = 255;

    /// <summary>
    ///     Initializes a new <see cref="SourceId"/> with the given raw string value.
    /// </summary>
    /// <param name="value">The raw source identifier string. Must be non-null, non-whitespace, and at most 255 characters.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, whitespace, or exceeds the maximum length.</exception>
    public SourceId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SourceId cannot be null, empty, or whitespace.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"SourceId cannot be longer than {MaxLength} characters.", nameof(value));

        Value = value;
    }

    /// <summary>
    ///     Gets the underlying primitive value.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    public override string ToString() => Value;
}

