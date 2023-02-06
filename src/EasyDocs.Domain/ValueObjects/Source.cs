using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Source : ValueObject
{
    private Source()
    { }

    public Source(string text)
    {
        Text = text;

        AddNotifications(new Contract<Source>()
            .Requires()
             .IsNotNullOrEmpty(Text, "Source.Text", "A origem não pode ser vazia.")
            .IsNotNullOrWhiteSpace(Text, "Source.Text", "A origem não pode ser vazia.")
            .IsLowerOrEqualsThan(5, Text.Length, "Source.Text", "A origem não deve conter menos de 5 caracteres.")
            .IsGreaterOrEqualsThan(250, Text.Length, "Source.Text", "A origem não deve conter mais de 250 caracteres.")
            );
    }

    public string Text { get; private set; } = string.Empty;
}