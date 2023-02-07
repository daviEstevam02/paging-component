using EasyDocs.Application.Auth;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ServiceResponse> Login(string email, string password)
    {
        if (email.IsEmpty()) return new ServiceResponse(false, "Email inválido.");
        if (password.IsEmpty()) return new ServiceResponse(false, "Senha inválida.");

        var userExists = await _userRepository.GetOneWhere(u => u.Email.Address == email
        && u.Password.PasswordTyped == password);

        if (userExists is null)
            return new ServiceResponse(false, "Usuário inexistente.");

        var token = TokenServices.GenerateToken(userExists);

        return new ServiceResponse(true, token);
    }
}