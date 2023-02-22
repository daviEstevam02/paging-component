using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Authorize]
[Route("users")]
public sealed class UserController : ApiController
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    /// <summary>
    /// Realiza o login do usuário, retornando o token Bearer (JWT) se obter sucesso ou uma mensagem de erro caso haja falha.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] RequestLoginViewModel viewModel)
        => CustomResponse(await _userServices.Login(viewModel.Email, viewModel.Senha));

    /// <summary>
    /// Retorna todos os Usuários cadastrados interligados com a Empresa especificada.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{companyId}")]
    public async Task<IEnumerable<ResponseUserViewModel>> GetAll(Guid companyId)
       => await _userServices.GetAll(companyId);

    /// <summary>
    /// Retorna o Usuário com o código especificado na URL.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{userId}")]
    public async Task<ResponseUserViewModel> GetById(Guid userId)
       => await _userServices.GetById(userId);

    /// <summary>
    /// Realiza a criação de um Usuário através de um Form, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostUserViewModel viewModel)
        => CustomResponse(await _userServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de um Usuário através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromForm] PutUserViewModel viewModel)
        => CustomResponse(await _userServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de um Usuário através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserViewModel viewModel)
        => CustomResponse(await _userServices.Delete(viewModel));
}