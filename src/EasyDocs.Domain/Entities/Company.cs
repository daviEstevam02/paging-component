using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Company : Entity
{
    private Company() // Empty EF Constructor
    { }

    public Company(
        Guid id,
        FantasyName fantasyName, 
        LegalName legalName, 
        CNPJ cnpj
        ) : base(id)
    {
        LegalName = legalName;
        FantasyName = fantasyName;
        Cnpj = cnpj;

        AddNotifications(LegalName, FantasyName, Cnpj);
    }

    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;

    public IList<Establishment> Establishments { get; private set; } = null!;
    public IList<AccessLevel> AccessLevels { get; private set; } = null!;
}