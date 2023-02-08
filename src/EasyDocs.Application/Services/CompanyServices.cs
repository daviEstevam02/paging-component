using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.CrossCutting.Bus;

namespace EasyDocs.Application.Services;

public sealed class CompanyServices : ICompanyServices
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IMediatorHandler _mediator;

    public CompanyServices(IMapper mapper, ICompanyRepository companyRepository, IMediatorHandler mediator)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ResponseCompanyViewModel>> GetAll(Guid licenseeId)
       => _mapper.Map<IEnumerable<ResponseCompanyViewModel>>(await _companyRepository.GetAll(c => c.LicenseeId == licenseeId));

    public async Task<ServiceResponse> Create(PostCompanyViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateCompanyCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}