using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class FantasyName : ValueObject
{
	private FantasyName() // Empty constructor for EF
	{ }

	public FantasyName(string name)
	{
		Name = name;

		AddNotifications(new Contract<FantasyName>()
			.Requires()
			.IsNotNullOrEmpty(Name, "FantasyName.Name", "O nome fantasia não pode ser vazio.")
			.IsNotNullOrWhiteSpace(Name, "FantasyName.Name", "O nome fantasia não pode ser vazio.")
			.IsGreaterOrEqualsThan(Name.Length, 3, "FantasyName.Name", "O nome fantasia não pode ter menos de 3 caracteres.")  
			.IsLowerOrEqualsThan(Name.Length, 150, "FantasyName.Name", "O nome fantasia não pode ter mais de 150 caracteres.")  
			);
	}

	public string Name { get; private set; } = string.Empty;
}
