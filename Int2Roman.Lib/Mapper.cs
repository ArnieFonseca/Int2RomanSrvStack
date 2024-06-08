namespace Int2Roman.Lib;
 
/// <summary>
/// Immutable container that holds the Pair unsigned integer and a string.
/// The container servers a mapping between a non zero integer and a corresponding roman number
/// </summary>
public record Mapper
{
    /// <summary>
    /// Non zero integer representation
    /// </summary>
    public required ulong Number { get; init; }
    /// <summary>
    /// Roman number representation
    /// </summary>
    public required string Roman { get; init; }
}
