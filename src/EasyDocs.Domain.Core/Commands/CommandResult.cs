using Flunt.Notifications;

namespace Gooders.Shared.Core.Commands;

public sealed class CommandResult
{
    public CommandResult(bool success, List<Notification> errors)
    {
        Success = success;
        Errors = errors.Any() ? new List<Notification>() : errors;
    }

    public bool Success { get; private set; }
    public List<Notification> Errors { get; private set; }
}