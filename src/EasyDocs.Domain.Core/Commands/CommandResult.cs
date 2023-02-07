using Flunt.Notifications;

namespace Gooders.Shared.Core.Commands;

public sealed class CommandResult
{
    public CommandResult(bool success, object response)
    {
        Success = success;
        Response ??= response;
    }

    public bool Success { get; private set; }
    public object Response { get; private set; } = null;
}