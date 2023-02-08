using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;
using static System.Net.Mime.MediaTypeNames;

namespace EasyDocs.Domain.ValueObjects;

public sealed class LegalName : ValueObject
{
    private LegalName()
    { }

    public LegalName(string name)
    {
        Name = name;

        AddNotifications(new Contract<LegalName>()
            .Requires()
            .IsNotNullOrEmpty(Name, "LegalName.Name", "A razão social não deve ser vazia.")
            .IsNotNullOrWhiteSpace(Name, "LegalName.Name", "A razão social não deve ser vazia.")
            .IsLowerOrEqualsThan(3, Name.Length, "LegalName.Name", "A razão social deve conter mais de 3 caracteres.")
            .IsGreaterOrEqualsThan(200, Name.Length, "LegalName.Name", "A razão social deve conter menos de 200 caracteres.")
            );
    }

    public string Name { get; private set; } = string.Empty;

    public override string ToString() => Name;
}