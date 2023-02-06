using EasyDocs.Domain.Core.ValueObjects;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Description : ValueObject
{
    private Description()
    { }

    public Description(string text)
    {
        Text = text;
    }

    public string Text { get; private set; } = string.Empty;
}