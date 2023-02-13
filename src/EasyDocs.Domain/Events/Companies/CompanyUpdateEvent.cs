using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Companies;

public sealed class CompanyUpdateEvent : Event
{
    public CompanyUpdateEvent(
        Guid id,
        Guid licenseeId, 
        FantasyName fantasyName, 
        LegalName legalName, 
        Address address, 
        Phone contact, 
        CNPJ cnpj, 
        bool isHeadquarter,
        Guid userId,
        string username
        ) : base(EAction.Updated, userId, username, EntitiesContexts.COMPANIES)
    {
        Id = id;
        AggregateId = id;
        LicenseeId = licenseeId;
        FantasyName = fantasyName;
        LegalName = legalName;
        Address = address;
        Contact = contact;
        Cnpj = cnpj;
        IsHeadquarter = isHeadquarter;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Phone Contact { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;
    public bool IsHeadquarter { get; private set; }
}
