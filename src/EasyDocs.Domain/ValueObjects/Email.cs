using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private Email() 
    { }

    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsNotEmail(Address, "Email.Address", "Email inválido.")
            );
    }

    public string Address { get; private set; } = string.Empty;
}