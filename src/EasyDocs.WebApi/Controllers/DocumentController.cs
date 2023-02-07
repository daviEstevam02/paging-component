using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Documents;
using Gooders.Services.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Route("documents")]
[Authorize]
public sealed class DocumentController : ApiController
{
    private readonly IDocumentServices _documentServices;

    public DocumentController(IDocumentServices documentServices)
    {
        _documentServices = documentServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostDocumentViewModel viewModel)
        => CustomResponse(await _documentServices.Create(viewModel));
}