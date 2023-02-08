using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using Gooders.Shared.Core.Commands;

namespace EasyDocs.Domain.Commands.Companies;

public sealed class CreateCompanyCommand : Command
{
    public CreateCompanyCommand(
        Guid licenseeId, 
        string fantasyName, 
        string legalName, 
        string country, 
        string state, 
        string city, 
        string neighborhood, 
        string street, 
        string number, 
        string compliment, 
        string contact, 
        string cnpj, 
        bool isHeadquarter, 
        Guid userId
        )
    {
        LicenseeId = licenseeId;
        FantasyName = fantasyName;
        LegalName = legalName;
        Country = country;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        Compliment = compliment;
        Contact = contact;
        Cnpj = cnpj;
        IsHeadquarter = isHeadquarter;
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public Guid LicenseeId { get; private set; }
    public string FantasyName { get; private set; }
    public string LegalName { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Compliment { get; private set; }
    public string Contact { get; private set; }
    public string Cnpj { get; private set; }
    public bool IsHeadquarter { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateCnpj();
    }

    public void ValidateCnpj()
    {
        AddNotifications(new Contract<CreateCompanyCommand>()
            .Requires()
            .IsCnpj(Number, "CreateCompanyCommand.CNPJ", "CNPJ inválido.")
            );
    }
    #endregion
}