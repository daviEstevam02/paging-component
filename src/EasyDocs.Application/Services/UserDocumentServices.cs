using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.UserDocuments;
using EasyDocs.Domain.Commands.UserDocuments;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class UserDocumentServices : IUserDocumentServices
{
    private readonly IMapper _mapper;
    private readonly IUserDocumentRepository _userDocumentRepository;
    private readonly IMediatorHandler _mediator;

    public UserDocumentServices(
        IMapper mapper,
        IUserDocumentRepository userDocumentRepository,
        IMediatorHandler mediator)

    {
        _mapper = mapper;
        _userDocumentRepository = userDocumentRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseUserDocumentViewModel>> GetAll(Guid companyId)
    => _mapper.Map<IEnumerable<ResponseUserDocumentViewModel>>
        (await _userDocumentRepository.GetAll(d => d.CompanyId == companyId));

    public async Task<ResponseUserDocumentViewModel> GetById(Guid userDocumentId)
       => _mapper.Map<ResponseUserDocumentViewModel>
            (await _userDocumentRepository.GetOneWhere(d => d.Id == userDocumentId));

    public async Task<ServiceResponse> Create(PostUserDocumentViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateUserDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteUserDocumentViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<DeleteUserDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
    public async Task<ServiceResponse> Update(PutUserDocumentViewModel viewModel)
    {
        var update = _mapper.Map<UpdateUserDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(update);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}
