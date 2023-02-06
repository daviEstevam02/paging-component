using EasyDocs.Domain.Core.ValueObjects;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private Address() 
    { }

    public Address(
        string country, 
        string federativeUnit, 
        string city, 
        string neighborhood, 
        string street, 
        string number, 
        string compliment
        )
    {
        Country = country;
        FederativeUnit = federativeUnit;
        City = city;
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        Compliment = compliment;
    }

    public string Country { get; private set; } = string.Empty;
    public string FederativeUnit { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Compliment { get; private set; } = string.Empty;
}