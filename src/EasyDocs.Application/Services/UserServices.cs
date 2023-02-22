using AutoMapper;
using EasyDocs.Application.Auth;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Users;
using EasyDocs.Domain.Commands.Users;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _mediator;

    public UserServices(IUserRepository userRepository, IMapper mapper, IMediatorHandler mediator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseUserViewModel>> GetAll(Guid companyId)
        => _mapper.Map<IEnumerable<ResponseUserViewModel>>
        (await _userRepository.GetAll(u => u.CompanyId == companyId));

    public async Task<ResponseUserViewModel> GetById(Guid userId)
    => _mapper.Map<ResponseUserViewModel>
        (await _userRepository.GetOneWhere(u => u.Id == userId));

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

    public async Task<ServiceResponse> Create(PostUserViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateUserCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Update(PutUserViewModel viewModel)
    {
        var updateCommand = _mapper.Map<UpdateUserCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(updateCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteUserViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<DeleteUserCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}