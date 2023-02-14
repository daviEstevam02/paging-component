using EasyDocs.Application.Interfaces;
using EasyDocs.Application.Services;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Application.ViewModels.UserDocuments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;
[Authorize]
[Route("userDocuments")]
public sealed class UserDocumentController : ApiController
{
    private readonly IUserDocumentServices _userDocumentServices;

	public UserDocumentController(IUserDocumentServices userDocumentServices)
	{
		_userDocumentServices = userDocumentServices;
	}


    /// <summary>
    /// Retorna todos os Usuarios por documentos cadastrados interligados com a Empresa especificada.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{companyId}")]
    public  async Task<IEnumerable<ResponseUserDocumentViewModel>> GetAll(Guid companyId)
       => await _userDocumentServices.GetAll(companyId);

    /// <summary>
    /// Retorna o  Usuário por documento com o código especificado na URL.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{userDocumentId}")]
    public async Task<ResponseUserDocumentViewModel> GetById(Guid userDocumentId)
       => await _userDocumentServices.GetById(userDocumentId);

    /// <summary>
    /// Realiza a criação de um Usuário por document através de um Form, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostUserDocumentViewModel viewModel)
        => CustomResponse(await _userDocumentServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de um Uusário por documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromForm] PutUserDocumentViewModel viewModel)
        => CustomResponse(await _userDocumentServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de um Usuário por documento através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserDocumentViewModel viewModel)
        => CustomResponse(await _userDocumentServices.Delete(viewModel));
}
