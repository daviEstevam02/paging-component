using EasyDocs.Domain.Events.Companies;
using MediatR;

namespace EasyDocs.Domain.Handlers.Companies;

public sealed class CompanyEventHandler :
    INotificationHandler<CompanyCreatedEvent>
{
    public Task Handle(CompanyCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}