using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Company : Entity
{
    private Company()
    { }

    public Guid LicenseeId { get; private set; }
    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Phone Contact { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;
    public bool IsHeadquarter { get; private set; }

    public Licensee Licensee { get; private set; } = null!;
}