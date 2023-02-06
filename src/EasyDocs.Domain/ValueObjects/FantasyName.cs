using EasyDocs.Domain.Core.ValueObjects;

namespace EasyDocs.Domain.ValueObjects;

public sealed class FantasyName : ValueObject
{
    private FantasyName()
    { }

    public FantasyName(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;
}