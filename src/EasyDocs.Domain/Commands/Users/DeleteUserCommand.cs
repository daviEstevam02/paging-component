using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Users;

public sealed class DeleteUserCommand : Command
{
    public DeleteUserCommand(Guid id, Guid userId) =>
        (Id, UserId, AggregateId) = (id, userId, id);

    public Guid Id { get; private set; }

    #region Fail Fast Validations
    public override void Validate() 
        => ValidateId();

    public void ValidateId() 
        => AddNotifications(new Contract<DeleteUserCommand>()
            .Requires()
            .IsTrue(Id != Guid.Empty, "DeleteUserCommand.Id", "O código do usuário não pode ser vazio.")
            );
    
    #endregion
}