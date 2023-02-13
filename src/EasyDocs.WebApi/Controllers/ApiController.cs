using EasyDocs.Application.Core;
using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult CustomResponse(ServiceResponse? result = null)
    {
        if (result!.Messages.GetType() == typeof(List<Notification>))
        {
            var notifications = result.Messages as List<Notification>;
            foreach (var error in notifications!)
            {
                AddError($"{error.Key} | {error.Message}");
            }
        }
        else if (result.Success is false)
        {
            var error = result.Messages as string;
            AddError(error!);
        }

        if (IsOperationValid())
            return Ok(result.Messages);

        return BadRequest(new Dictionary<string, string[]>
        {
            { $"Erros", _errors.ToArray() }
        });
    }

    protected bool IsOperationValid() => !_errors.Any();

    protected void AddError(string notification) => _errors.Add(notification);

    protected void ClearErrors() => _errors.Clear();
}
