using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Documents;
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

    /// <summary>
    /// Realiza a criação de um Documento através de um Form, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostDocumentViewModel viewModel)
        => CustomResponse(await _documentServices.Create(viewModel));
}