using EasyDocs.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Username : ValueObject
{
    private Username() 
    { }

    public Username(string nickname)
    {
        Nickname = nickname;

        AddNotifications(new Contract<Username>()
            .IsNotNullOrEmpty(Nickname, "Username.Nickname", "O nome de usuário não deve ser vazio.")
            .IsNotNullOrWhiteSpace(Nickname, "Username.Nickname", "O nome de usuário não deve ser vazio.")
            .IsLowerOrEqualsThan(5, Nickname.Length, "Username.Nickname", "O nome de usuário não deve conter menos de 5 caracteres.")
            .IsGreaterOrEqualsThan(30, Nickname.Length, "Username.Nickname", "O nome de usuário não deve conter mais de 20 caracteres.")
            );
    }

    public string Nickname { get; private set; } = string.Empty;    
}