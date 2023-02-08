using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Core.Messaging;
using MediatR;

namespace EasyDocs.Infra.CrossCutting.Bus;

public sealed class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IEventStore _eventStore;

    public InMemoryBus(IEventStore eventStore, IMediator mediator)
    {
        _eventStore = eventStore;
        _mediator = mediator;
    }

    public async Task PublishEvent<T>(T theEvent) where T : Event
    {
        if (!theEvent.Entity.Equals("DomainNotification"))
            _eventStore?.Save(theEvent);

        await _mediator.Publish(theEvent);
    }

    public async Task<CommandResult> SendCommand<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }
}