namespace Margorak.Api.Configuration;

public sealed class StartingItemOptions
{
    public const string SectionName = "StartingItems";

    public List<StartingItemDefinition> Default { get; set; } = [];
    public Dictionary<int, List<StartingItemDefinition>> ByClass { get; set; } = [];
}

public sealed class StartingItemDefinition
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}
