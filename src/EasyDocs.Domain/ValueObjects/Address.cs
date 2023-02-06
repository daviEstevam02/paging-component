using EasyDocs.Domain.Core.ValueObjects;
using EasyDocs.Domain.Helpers;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private Address() 
    { }

    public Address(
        string country, 
        string state, 
        string city, 
        string neighborhood, 
        string street, 
        string number, 
        string compliment
        )
    {
        Country = country;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        Compliment = compliment;

        Validate();
    }

    public string Country { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Compliment { get; private set; } = string.Empty;

    #region Validations
    private void Validate()
    {
        ValidateCountry();
        ValidateState();
        ValidateCity();
        ValidateNeighborhood();
        ValidateStreet();
        ValidateNumber();
        ValidateCompliment();
    }

    public void ValidateCountry()
    {
        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(Country, "Address.Country", "O país não deve ser vazio.")
            .IsNotNullOrWhiteSpace(Country, "Address.Country", "O país não deve ser vazio.")
            .IsLowerOrEqualsThan(2, Country.Length, "Address.Country", "O país não deve conter menos de 3 caracteres.")
            .IsGreaterOrEqualsThan(100, Country.Length, "Address.Country", "O país não deve conter mais de 100 caracteres.")
            );
    }

    public void ValidateState()
    {
        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(State, "Address.State", "O estado não deve ser vazio.")
            .IsNotNullOrWhiteSpace(State, "Address.State", "O estado não deve ser vazio.")
            .AreNotEquals(2, State.Length, "Address.State", "O estado deve conter 2 caracteres.")
            );
    }

    public void ValidateCity()
    {
        AddNotifications(new Contract<Address>()
          .Requires()
          .IsNotNullOrEmpty(City, "Address.City", "A cidade não deve ser vazia.")
          .IsNotNullOrWhiteSpace(City, "Address.City", "A cidade não deve ser vazia.")
          .IsLowerOrEqualsThan(2, City.Length, "Address.City", "A cidade não deve conter menos de 3 caracteres.")
          .IsGreaterOrEqualsThan(200, City.Length, "Address.City", "A cidade não deve conter mais de 200 caracteres.")
          );
    }

    public void ValidateNeighborhood()
    {
        AddNotifications(new Contract<Address>()
          .Requires()
          .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "O bairro não deve ser vazio.")
          .IsNotNullOrWhiteSpace(Neighborhood, "Address.Neighborhood", "O bairro não deve ser vazio.")
          .IsLowerOrEqualsThan(2, Neighborhood.Length, "Address.Neighborhood", "O bairro não deve conter menos de 3 caracteres.")
          .IsGreaterOrEqualsThan(200, Neighborhood.Length, "Address.Neighborhood", "O bairro não deve conter mais de 200 caracteres.")
          );
    }

    public void ValidateStreet()
    {
        AddNotifications(new Contract<Address>()
          .Requires()
          .IsNotNullOrEmpty(Street, "Address.Street", "A rua não deve ser vazia.")
          .IsNotNullOrWhiteSpace(Street, "Address.Street", "A rua não deve ser vazia.")
          .IsLowerOrEqualsThan(2, Street.Length, "Address.Street", "A rua não deve conter menos de 3 caracteres.")
          .IsGreaterOrEqualsThan(200, Street.Length, "Address.Street", "A rua não deve conter mais de 200 caracteres.")
          );
    }

    public void ValidateNumber()
    {
        AddNotifications(new Contract<Address>()
          .Requires()
          .IsNotNullOrEmpty(Number, "Address.Number", "O número não deve ser vazio.")
          .IsNotNullOrWhiteSpace(Number, "Address.Number", "O número não deve ser vazio.")
          .IsLowerOrEqualsThan(2, Number.Length, "Address.Number", "O número não deve conter menos de 3 caracteres.")
          .IsGreaterOrEqualsThan(10, Number.Length, "Address.Number", "O número não deve conter mais de 10 caracteres.")
          .IsFalse(Number.IsNumeric(), "Address.Number", "O número só deve conter caracteres numéricos.")
          );
    }

    public void ValidateCompliment()
    {
        AddNotifications(new Contract<Address>()
         .Requires()
         .IsNotNullOrEmpty(Compliment, "Address.Compliment", "O complemento não deve ser vazio.")
         .IsNotNullOrWhiteSpace(Compliment, "Address.Compliment", "O complemento não deve ser vazio.")
         .IsLowerOrEqualsThan(2, Compliment.Length, "Address.Compliment", "O complemento não deve conter menos de 3 caracteres.")
         .IsGreaterOrEqualsThan(200, Compliment.Length, "Address.Compliment", "O complemento não deve conter mais de 200 caracteres.")
         );
    }
    #endregion
}