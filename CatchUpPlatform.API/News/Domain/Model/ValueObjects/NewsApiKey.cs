namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

/// <summary>
///     Value object representing a validated News API key.
/// </summary>
public sealed record NewsApiKey
{
    private const int MaxLength = 255;

    /// <summary>
    ///     Initializes a new <see cref="NewsApiKey"/> with the given raw string value.
    /// </summary>
    /// <param name="value">The raw News API key string. Must be non-null, non-whitespace, and at most 255 characters.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, whitespace, or exceeds the maximum length.</exception>
    public NewsApiKey(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("NewsApiKey cannot be null, empty, or whitespace.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"NewsApiKey cannot be longer than {MaxLength} characters.", nameof(value));

        Value = value;
    }

    /// <summary>
    ///     Gets the underlying primitive value.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    public override string ToString() => Value;
    
    /// <summary>
    ///    Returns a masked version of the NewsApiKey for logging purposes, showing only the last 4 characters.
    /// </summary>
    /// <returns>
    ///   A string with all but the last 4 characters replaced by asterisks. If the key is 4 characters or shorter, all characters are masked.
    /// </returns>
    public string MaskedForLogging() => MaskedForLogging(Value);

    /// <summary>
    ///     Masks a raw News API key for logging, including values that have not passed validation.
    /// </summary>
    /// <param name="value">The raw key value to mask.</param>
    /// <returns>The masked key, showing only its last four characters when available.</returns>
    public static string MaskedForLogging(string? value) =>
        string.IsNullOrEmpty(value)
            ? string.Empty
            : value.Length <= 4
                ? new string('*', value.Length)
                : new string('*', value.Length - 4) + value[^4..];
}
