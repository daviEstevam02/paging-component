using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace EasyDocs.Domain.ValueObjects;

public sealed class CNPJ : ValueObject
{
    private CNPJ()
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

    public override string ToString() => Number;
}