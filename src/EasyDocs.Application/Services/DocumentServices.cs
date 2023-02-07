using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.CrossCutting.Bus;

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

    public async Task<ServiceResponse> Create(PostDocumentViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateDocumentCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}