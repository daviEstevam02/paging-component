using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Company : BaseEntity
{
    private Company()
    { }

    public Guid LicenseeId { get; private set; }
    public FantasyName FantasyName { get; private set; }
    public LegalName LegalName { get; private set; }
    public Address Address { get; private set; }
    public Phone Contact { get; private set; }
    public CNPJ Cnpj { get; private set; }
    public bool IsHeadquarter { get; private set; }

    public Licensee Licensee { get; private set; }
}