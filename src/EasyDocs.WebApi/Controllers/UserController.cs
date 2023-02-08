using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Route("users")]
[Authorize]
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
    public async Task<IActionResult> Login([FromBody] LoginRequestViewModel viewModel)
        => CustomResponse(await _userServices.Login(viewModel.Email, viewModel.Senha));
}