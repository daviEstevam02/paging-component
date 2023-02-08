using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Domain.Core.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T theEvent) where T : Event;

    Task<CommandResult> SendCommand<T>(T command) where T : Command;
}