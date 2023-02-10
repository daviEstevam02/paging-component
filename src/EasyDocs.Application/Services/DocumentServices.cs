using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class DocumentServices : IDocumentServices
{
    private readonly IMapper _mapper;
    private readonly IDocumentRepository _documentRepository;
    private readonly IMediatorHandler _mediator;

    public DocumentServices(IMapper mapper, IDocumentRepository documentRepository, IMediatorHandler mediator)
    {
        _mapper = mapper;
        _documentRepository = documentRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseAllDocumentViewModel>> GetAll(Guid companyId)
        => _mapper.Map<IEnumerable<ResponseAllDocumentViewModel>>
        (await _documentRepository.GetAll(d => d.CompanyId == companyId));

    public async Task<ResponseOneDocumentViewModel> GetById(Guid documentId)
     => _mapper.Map<ResponseOneDocumentViewModel>
        (await _documentRepository.GetOneWhere(d => d.Id == documentId));

    public async Task<ServiceResponse> Create(PostDocumentViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Update(PutDocumentViewModel viewModel)
    {
        var updateCommand = _mapper.Map<CreateDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(updateCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteDocumentViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<CreateDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}