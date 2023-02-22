using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.DocumentTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Authorize]
[Route("documentTypes")]
public sealed class DocumentTypeController : ApiController
{
    private readonly IDocumentTypeServices _documentTypeServices;

    public DocumentTypeController(IDocumentTypeServices documentTypeServices)
    {
        _documentTypeServices = documentTypeServices;
    }

    /// <summary>
    /// Retorna todas os Tipos de Documentos cadastrados interligados com a Empresa especificada.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{companyId}")]
    public async Task<IEnumerable<ResponseDocumentTypeViewModel>> GetAll(Guid companyId)
       => await _documentTypeServices.GetAll(companyId);

    /// <summary>
    /// Retorna o Tipo de Documento com o código especificado na URL.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{documentTypeId}")]
    public async Task<ResponseDocumentTypeViewModel> GetById(Guid documentTypeId)
       => await _documentTypeServices.GetById(documentTypeId);

    /// <summary>
    /// Realiza a criação de um Tipo de Documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostDocumentTypeViewModel viewModel)
        => CustomResponse(await _documentTypeServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de um Tipo de Documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PutDocumentTypeViewModel viewModel)
        => CustomResponse(await _documentTypeServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de um Tipo de Documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteDocumentTypeViewModel viewModel)
        => CustomResponse(await _documentTypeServices.Delete(viewModel));
}