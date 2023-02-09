using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class DocumentTypeServices : IDocumentTypeServices
{
    private readonly IMapper _mapper;
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly IMediatorHandler _mediator;

    public DocumentTypeServices(IMapper mapper, IDocumentTypeRepository documentTypeRepository, IMediatorHandler mediator)
    {
        _mapper = mapper;
        _documentTypeRepository = documentTypeRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseDocumentTypeViewModel>> GetAll(Guid companyId)
        => _mapper.Map<IEnumerable<ResponseDocumentTypeViewModel>>
        (await _documentTypeRepository.GetAll(dt => dt.CompanyId == companyId));

    public async Task<ResponseDocumentTypeViewModel> GetById(Guid documentTypeId)
    => _mapper.Map<ResponseDocumentTypeViewModel>
        (await _documentTypeRepository.GetOneWhere(dt => dt.Id == documentTypeId));

    public async Task<ServiceResponse> Create(PostDocumentTypeViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateDocumentTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Update(PutDocumentTypeViewModel viewModel)
    {
        var updateCommand = _mapper.Map<UpdateDocumentTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(updateCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteDocumentTypeViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<DeleteDocumentTypeCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}