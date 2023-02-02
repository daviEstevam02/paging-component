using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;
using Flunt.Br;
using Flunt.Validations;

namespace EasyDocs.Domain.Entities;

public sealed class Establishment : Entity
{
    private Establishment() // Empty constructor for EF
    { }

    public Establishment(
        Guid id, 
        Guid companyId, 
        ErpCodes codes, 
        FantasyName fantasyName,
        LegalName legalName, 
        Address address, 
        Phone contact,
        CNPJ cnpj, 
        bool isHeadquarter
        ) : base(id)
    {
        CompanyId = companyId;
        Codes = codes;
        FantasyName = fantasyName;
        LegalName = legalName;
        Address = address;
        Contact = contact;
        Cnpj = cnpj;
        IsHeadquarter = isHeadquarter;

        AddNotifications(Codes, FantasyName, LegalName, Address, Contact, Cnpj,
            new Contract<Establishment>()
            .Requires()
            .IsTrue(CompanyId == Guid.Empty, "Establishment.CompanyId", "O código do estabelecimento não pode ser vazio.")
            );
    }

    public Guid CompanyId { get; private set; }
    public ErpCodes Codes { get; private set; } = null!;
    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Phone Contact { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;
    public bool IsHeadquarter { get; private set; }

    public Company Company { get; private set; } = null!;
    public IList<AccessLevel> AccessLevels { get; private set; } = null!;
}