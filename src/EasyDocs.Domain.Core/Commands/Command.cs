using EasyDocs.Domain.Core.Messaging;
using MediatR;

namespace Gooders.Shared.Core.Commands;

public abstract class Command : Message, IRequest<CommandResult>, IBaseRequest
{
    public abstract void Validate();
}