using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Companies;

public sealed class CompanyCreatedEvent : Event
{
    public CompanyCreatedEvent(
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
        )  
        : base(EAction.Created, userId, username, EntitiesContexts.COMPANIES)
    {
        AggregateId = id;
        Id = id;
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
    public FantasyName FantasyName { get; private set; }
    public LegalName LegalName { get; private set; }
    public Address Address { get; private set; }
    public Phone Contact { get; private set; }
    public CNPJ Cnpj { get; private set; }
    public bool IsHeadquarter { get; private set; }
}