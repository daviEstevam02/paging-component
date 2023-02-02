using EasyDocs.Domain.Core.ValueObjects;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private Address() // Empty constructor for EF
    { }

    public Address(
        string country, 
        string city,
        string neighbourhood, 
        string street,
        string number,
        string complement
        )
    {
        Country = country;
        City = city;
        Neighbourhood = neighbourhood;
        Street = street;
        Number = number;
        Complement = complement;
    }

    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Neighbourhood { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Complement { get; private set; } = null!;
}