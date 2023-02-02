using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class CNPJ : ValueObject
{
	private CNPJ() // Empty constructor for EF
	{ }

	public CNPJ(string number)
	{
		Number = number;

		AddNotifications(new Contract<CNPJ>()
			.Requires()
			.IsCnpj(Number, "CNPJ.Number", "CNPJ inválido.")
			);
	}

	public string Number { get; private set; } = string.Empty;
}