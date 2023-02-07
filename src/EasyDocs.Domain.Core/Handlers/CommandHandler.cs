using EasyDocs.Domain.Core.Transactions;
using Flunt.Notifications;
using Gooders.Shared.Core.Commands;

namespace EasyDocs.Domain.Core.Handlers;

public abstract class CommandHandler
{
    protected List<Notification> Errors;

    protected CommandHandler()
    {
        Errors = new List<Notification>();
    }

    protected void AddError(string message)
    {
        Errors.Add(new Notification(string.Empty, message));
    }

    protected async Task<CommandResult> Commit(IUnitOfWork unitOfWork, string message)
    {
        if (!await unitOfWork.Commit())
        {
            AddError(message);
            return new CommandResult(false, Errors);
        }

        return new CommandResult(true, Errors);
    }

    protected async Task<CommandResult> Commit(IUnitOfWork uow)
    {
        return await Commit(uow, "Erro ao salvar os dados.").ConfigureAwait(continueOnCapturedContext: false);
    }
}