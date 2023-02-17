using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.UserTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Authorize]
[Route("userTypes")]
public sealed class UserTypeController : ApiController
{
    private readonly IUserTypeServices _userTypeServices;

    public UserTypeController(IUserTypeServices userTypeServices)
    {
        _userTypeServices = userTypeServices;
    }

    /// <summary>
    /// Retorna todas os Tipos de Usuário cadastrados interligados com a Empresa especificada.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{companyId}")]
    public async Task<IEnumerable<ResponseUserTypeViewModel>> GetAll(Guid companyId)
       => await _userTypeServices.GetAll(companyId);

    /// <summary>
    /// Retorna o Tipo de Usuário com o código especificado na URL.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{userTypeId}")]
    public async Task<ResponseUserTypeViewModel> GetById(Guid userTypeId)
       => await _userTypeServices.GetById(userTypeId);

    /// <summary>
    /// Realiza a criação de um Tipo de Usuário através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostUserTypeViewModel viewModel)
        => CustomResponse(await _userTypeServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de um Tipo de Usuário através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PutUserTypeViewModel viewModel)
        => CustomResponse(await _userTypeServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de um Tipo de Usuário através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserTypeViewModel viewModel)
        => CustomResponse(await _userTypeServices.Delete(viewModel));
}