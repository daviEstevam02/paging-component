using EasyDocs.Domain.Core.ValueObjects;
using EasyDocs.Domain.Helpers;
using Flunt.Validations;

namespace EasyDocs.Domain.ValueObjects;

public sealed class Password : ValueObject
{
    public Password(string passwordTyped)
    {
        PasswordTyped = passwordTyped;

        AddNotifications(new Contract<Password>()
            .Requires()
            .IsNotNullOrWhiteSpace(PasswordTyped, "Password.PasswordTyped", "A senha não deve ser vazia.")
            .IsNotNullOrEmpty(PasswordTyped, "Password.PasswordTyped", "A senha não deve ser vazia.")
            .IsLowerThan(6, PasswordTyped.Length, "Password.PasswordTyped", "A senha deve conter mais de 6 caracteres.")
            .IsGreaterThan(16, PasswordTyped.Length, "Password.PasswordTyped", "A senha deve conter menos de 16 caracteres.")
            .IsTrue(Validate(), "Password.PasswordTyped", "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um carácter especial.")
            );
    }

    public string PasswordTyped { get; private set; }

    private bool Validate()
        => PasswordTyped.HasUpperCase()
        && PasswordTyped.HasLowerCase()
        && PasswordTyped.HasSpecialChar()
        && PasswordTyped.HasNumber();
}