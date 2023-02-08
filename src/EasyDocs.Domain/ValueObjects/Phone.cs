using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using static System.Net.Mime.MediaTypeNames;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Phone : ValueObject
{
    private Phone()
    { }

    public Phone(string number)
    {
        Number = number;

        AddNotifications(new Contract<Phone>()
            .Requires()
            .IsPhoneNumber(Number, "Phone.Number", "Telefone inválido.")
            );
    }

    public string Number { get; private set; } = string.Empty;

    public override string ToString() => Number;
}