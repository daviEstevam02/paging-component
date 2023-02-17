using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.UserTypes;
using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Commands.UserTypes;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class UserTypeServices : IUserTypeServices
{
    private readonly IMapper _mapper;
    private readonly IUserTypeRepository _userTypeRepository;
    private readonly IMediatorHandler _mediator;

    public UserTypeServices(IMapper mapper, IUserTypeRepository userTypeRepository, IMediatorHandler mediator)
    {
        _mapper = mapper;
        _userTypeRepository = userTypeRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseUserTypeViewModel>> GetAll(Guid companyId)
        => _mapper.Map<IEnumerable<ResponseUserTypeViewModel>>
        (await _userTypeRepository.GetAll(ut => ut.CompanyId == companyId));

    public async Task<ResponseUserTypeViewModel> GetById(Guid userTypeId)
        => _mapper.Map<ResponseUserTypeViewModel>
        (await _userTypeRepository.GetOneWhere(ut => ut.Id == userTypeId));

    public async Task<ServiceResponse> Create(PostUserTypeViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateUserTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Update(PutUserTypeViewModel viewModel)
    {
        var updateCommand = _mapper.Map<UpdateUserTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(updateCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteUserTypeViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<DeleteUserTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}