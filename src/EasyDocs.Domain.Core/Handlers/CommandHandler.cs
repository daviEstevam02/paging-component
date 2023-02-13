using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Transactions;
using Flunt.Notifications;

namespace EasyDocs.Domain.Core.Handlers;

public class CommandHandler<T> : Notifiable<Notification> where T : Entity
{
    protected async Task<CommandResult> Commit(IUnitOfWork uow, string successMessage, string message)
    {
        if (!await uow.Commit())
            AddNotification(nameof(T), message);        

        if (!IsValid)
            return new CommandResult(false, Notifications);

        return new CommandResult(true, successMessage);
    }

    protected async Task<CommandResult> Commit(IUnitOfWork uow, string successMessage)
    {
        return await Commit(uow, successMessage, "Erro ao salvar as alterações.").ConfigureAwait(continueOnCapturedContext: false);
    }
}