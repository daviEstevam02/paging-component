using EasyDocs.Domain.Core.Entities;
using Flunt.Validations;

namespace EasyDocs.Domain.Entities;

public sealed class AccessLevel : Entity
{
    private AccessLevel() // Empty constructor for EF
    { }

    public AccessLevel(
        Guid companyId,
        Guid establishmentId, 
        bool humanResources,
        bool juridical, 
        bool financial,
        bool others
        )
    {
        CompanyId = companyId;
        EstablishmentId = establishmentId;
        HumanResources = humanResources;
        Juridical = juridical;
        Financial = financial;
        Others = others;

        AddNotifications(new Contract<AccessLevel>()
            .Requires()
            .IsTrue(CompanyId == Guid.Empty, "AccessLevel.CompanyId", "O código da empresa não pode ser vazio.")
            .IsTrue(EstablishmentId == Guid.Empty, "AccessLevel.EstablishmentId", "O código do estabelecimento não pode ser vazio.")
            );
    }

    public Guid CompanyId { get; private set; }
    public Guid EstablishmentId { get; private set; }
    public bool HumanResources { get; private set; }
    public bool Juridical { get; private set; }
    public bool Financial { get; private set; }
    public bool Others { get; private set; }
}