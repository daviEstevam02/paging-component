using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Documents;

public sealed class DeleteDocumentCommand : Command
{
    public DeleteDocumentCommand(Guid id, Guid userId) =>
        (Id, UserId, AggregateId) = (id, userId, id);

    public Guid Id { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateId();
    }

    public void ValidateId()
    {
        AddNotifications(new Contract<DeleteDocumentCommand>()
            .Requires()
            .IsTrue(Id != Guid.Empty, "DeleteDocumentCommand.Id", "O código do documento não pode ser vazio.")
            );
    }
    #endregion
}