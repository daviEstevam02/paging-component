using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class LegalName : ValueObject
{
	private LegalName() // Empty constructor for EF
	{ }

	public LegalName(string name)
	{
		Name = name;

		AddNotifications(new Contract<LegalName>()
			.Requires()
			.IsNotNullOrEmpty(Name, "LegalName.Name", "A razão social não pode ser vazia.")
			.IsNotNullOrWhiteSpace(Name, "LegalName.Name", "A razão social não pode ser vazia.")
            .IsGreaterOrEqualsThan(Name.Length, 3, "LegalName.Name", "A razão social não pode ter menos de 3 caracteres.")
            .IsLowerOrEqualsThan(Name.Length, 255, "LegalName.Name", "A razão social não pode ter mais de 255 caracteres.")
            );
	}

	public string Name { get; private set; } = string.Empty;
}