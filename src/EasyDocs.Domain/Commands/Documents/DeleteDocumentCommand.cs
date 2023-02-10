﻿using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Documents;

public sealed class DeleteDocumentCommand : Command
{
    public DeleteDocumentCommand(Guid id, Guid userId)
    {
        Id = id;
        AggregateId = id;
        UserId = userId;
    }

    public Guid Id { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateId();
    }

    public void ValidateId()
    {
        AddNotifications(new Contract<DeleteDocumentTypeCommand>()
            .Requires()
            .IsTrue(Id != Guid.Empty, "DeleteDocumentTypeCommand.Id", "O código do tipo de documento não pode ser vazio.")
            );
    }
    #endregion
}