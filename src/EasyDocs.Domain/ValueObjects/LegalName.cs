using EasyDocs.Domain.Core.ValueObjects;

namespace EasyDocs.Domain.ValueObjects;

public sealed class LegalName : ValueObject
{
    private LegalName()
    { }

    public LegalName(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;
}