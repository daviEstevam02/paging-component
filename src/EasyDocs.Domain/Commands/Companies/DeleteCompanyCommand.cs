using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Companies;

public sealed class DeleteCompanyCommand : Command
{
    public DeleteCompanyCommand(Guid id, Guid userId ) =>
        (Id, userId, AggregateId) = (id, userId,id);
   
    public Guid Id { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateId();
    }

    public void ValidateId()
    {
        AddNotifications(new Contract<DeleteCompanyCommand>()
            .Requires()
            .IsTrue(Id != Guid.Empty, "DeleteCompanyCommand.Id", "O código da empresa não pode ser vazio.")
            );
    }
    #endregion
}
