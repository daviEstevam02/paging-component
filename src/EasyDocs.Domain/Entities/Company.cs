using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Company : Entity
{
    private Company()
    { }

    public Company(
        Guid id,
        Guid licenseeId,
        FantasyName fantasyName,
        LegalName legalName,
        Address address,
        Phone contact,
        CNPJ cnpj,
        bool isHeadquarter
        ) : base(id)
    {
        LicenseeId = licenseeId;
        FantasyName = fantasyName;
        LegalName = legalName;
        Address = address;
        Contact = contact;
        Cnpj = cnpj;
        IsHeadquarter = isHeadquarter;

        AddNotifications(FantasyName, LegalName, Address, Contact, Cnpj);
    }

    public Guid LicenseeId { get; private set; }
    public FantasyName FantasyName { get; private set; } = null!;
    public LegalName LegalName { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Phone Contact { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;
    public bool IsHeadquarter { get; private set; }

    public Licensee Licensee { get; private set; } = null!;
    public List<Document> Documents { get; private set; } = null!;
    public List<DocumentType> DocumentTypes { get; private set; } = null!;
    public List<User> User { get; private set; } = null!;
    public List<UserDocument> UserDocuments { get; private set; } = null!;
    public List<UserType> UserTypes { get; private set; } = null!;
}