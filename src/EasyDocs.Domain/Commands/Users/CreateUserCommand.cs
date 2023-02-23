using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Enums;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Users;

public sealed class CreateUserCommand : Command
{
    public CreateUserCommand(
        Guid clientId, 
        string linkCode, 
        EUserTypes userType, 
        EDocumentGroup documentGroup, 
        string username, 
        string email, 
        string password,
        Guid userId)
    {
        UserId = userId;
        ClientId = clientId;
        UserType = userType;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        Username = username;
        Email = email;
        Password = password;
    }

    public Guid ClientId { get; private set; }
    public EUserTypes UserType { get; private set; }
    public string LinkCode { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateEmail();
        ValidatePassword();
    }

    public void ValidateEmail()
        => AddNotifications(new Contract<CreateUserCommand>()
            .Requires()
            .IsNotEmail(Email, "CreateUserCommand.Email", "Email inválido.")
            .IsGreaterOrEqualsThan(100, Email.Length, "CreateUserCommand.Email", "O email não deve conter mais de 100 caracteres.")
            );

    public void ValidatePassword()
        => AddNotifications(new Contract<CreateUserCommand>()
            .Requires()
            .IsNotNullOrWhiteSpace(Password, "CreateUserCommand.Password", "A senha não deve ser vazia.")
            .IsNotNullOrEmpty(Password, "CreateUserCommand.Password", "A senha não deve ser vazia.")
            .IsLowerThan(6, Password.Length, "CreateUserCommand.Password", "A senha deve conter mais de 6 caracteres.")
            .IsGreaterThan(16, Password.Length, "CreateUserCommand.Password", "A senha deve conter menos de 16 caracteres.")
            );
    #endregion
}