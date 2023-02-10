using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Documents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Authorize]
[Route("documents")]
public sealed class DocumentController : ApiController
{
    private readonly IDocumentServices _documentServices;

    public DocumentController(IDocumentServices documentServices)
    {
        _documentServices = documentServices;
    }

    /// <summary>
    /// Retorna todos os Documentos cadastrados interligados com a Empresa especificada.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{companyId}")]
    public async Task<IEnumerable<ResponseAllDocumentViewModel>> GetAll(Guid companyId)
       => await _documentServices.GetAll(companyId);

    /// <summary>
    /// Retorna o Documento com o código especificado na URL.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{documentId}")]
    public async Task<ResponseOneDocumentViewModel> GetById(Guid documentId)
       => await _documentServices.GetById(documentId);

    /// <summary>
    /// Realiza a criação de um Documento através de um Form, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostDocumentViewModel viewModel)
        => CustomResponse(await _documentServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de um Documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromForm] PutDocumentViewModel viewModel)
        => CustomResponse(await _documentServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de um Documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteDocumentViewModel viewModel)
        => CustomResponse(await _documentServices.Delete(viewModel));
}