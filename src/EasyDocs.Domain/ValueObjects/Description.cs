using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Description : ValueObject
{
    private Description()
    { }

    public Description(string text)
    {
        Text = text;

        AddNotifications(new Contract<Description>()
            .Requires()
            .IsNotNullOrEmpty(Text, "Description.Text", "A descrição não pode ser vazia.")
            .IsNotNullOrWhiteSpace(Text, "Description.Text", "A descrição não pode ser vazia.")
            .IsLowerOrEqualsThan(3, Text.Length, "Description.Text", "A descrição não deve conter menos de 3 caracteres.")
            .IsGreaterOrEqualsThan(150, Text.Length, "Description.Text", "A descrição não deve conter mais de 150 caracteres.")
            );
    }

    public string Text { get; private set; } = string.Empty;
}