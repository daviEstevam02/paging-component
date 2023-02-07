using EasyDocs.Domain.Core.Messaging;
using Gooders.Shared.Core.Commands;

namespace EasyDocs.Infra.CrossCutting.Bus;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T theEvent) where T : Event;

    Task<CommandResult> SendCommand<T>(T command) where T : Command;
}