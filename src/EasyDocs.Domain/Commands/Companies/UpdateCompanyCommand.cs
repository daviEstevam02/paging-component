using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Companies;

public sealed class UpdateCompanyCommand : Command
{
    public UpdateCompanyCommand(
        Guid id, 
        Guid licensseId, 
        FantasyName fantasyName, 
        LegalName legalName, 
        Address address, 
        Phone contact, 
        CNPJ cnpj, 
        bool isHeadquarter
        )
    {
        Id = id;
        LicensseId = licensseId;
        FantasyName = fantasyName;
        LegalName = legalName;
        Address = address;
        Contact = contact;
        Cnpj = cnpj;
        IsHeadquarter = isHeadquarter;
    }

    public Guid Id { get; private set; }
    public Guid LicensseId { get; private set; }
    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Phone Contact { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;
    public bool IsHeadquarter { get; private set; }


    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateIsHeadquarter();
    }

    public void ValidateIsHeadquarter()
    {
        AddNotifications(new Contract<UpdateCompanyCommand>()
            .Requires()
            );
    }
    #endregion
}
