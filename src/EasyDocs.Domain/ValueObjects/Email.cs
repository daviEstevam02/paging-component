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
            .IsGreaterOrEqualsThan(100, Address.Length, "Email.Address", "O email não deve conter mais de 100 caracteres.")
            );
    }

    public string Address { get; private set; } = string.Empty;
}