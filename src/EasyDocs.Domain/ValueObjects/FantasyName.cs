using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;
using static System.Net.Mime.MediaTypeNames;

namespace EasyDocs.Domain.ValueObjects;

public sealed class FantasyName : ValueObject
{
    private FantasyName()
    { }

    public FantasyName(string name)
    {
        Name = name;

        AddNotifications(new Contract<FantasyName>()
          .Requires()
          .IsNotNullOrEmpty(Name, "FantasyName.Name", "O nome fantasia não deve ser vazio.")
          .IsNotNullOrWhiteSpace(Name, "FantasyName.Name", "O nome fantasia não deve ser vazio.")
          .IsLowerOrEqualsThan(3, Name.Length, "FantasyName.Name", "O nome fantasia deve conter mais de 3 caracteres.")
          .IsGreaterOrEqualsThan(100, Name.Length, "FantasyName.Name", "O nome fantasia deve conter menos de 100 caracteres.")
          );
    }

    public string Name { get; private set; } = string.Empty;

    public override string ToString() => Name;
}