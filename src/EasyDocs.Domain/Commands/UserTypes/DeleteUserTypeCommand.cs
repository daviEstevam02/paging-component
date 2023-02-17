using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.UserTypes;

public sealed class DeleteUserTypeCommand : Command
{
    public DeleteUserTypeCommand(Guid id, Guid userId) =>
        (Id, UserId, AggregateId) = (id, userId, id);

    public Guid Id { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateId();
    }

    public void ValidateId() =>
         AddNotifications(new Contract<DeleteUserTypeCommand>()
            .Requires()
            .IsTrue(Id != Guid.Empty, "DeleteUserTypeCommand.Id", "O código do tipo de usuário não pode ser vazio.")
            );
    #endregion
}