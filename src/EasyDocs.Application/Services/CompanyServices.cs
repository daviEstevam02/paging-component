using AutoMapper;
using EasyDocs.Application.Core;
using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Application.Services;

public sealed class CompanyServices : ICompanyServices
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IMediatorHandler _mediator;

    public CompanyServices(IMapper mapper, 
        ICompanyRepository companyRepository, 
        IMediatorHandler mediator) => (_mapper, _companyRepository, _mediator) = (mapper, companyRepository, mediator); 
   

    public async Task<IEnumerable<ResponseCompanyViewModel>> GetAll(Guid licenseeId)
       => _mapper.Map<IEnumerable<ResponseCompanyViewModel>>
        (await _companyRepository.GetAll(c => c.LicenseeId == licenseeId));

    public async Task<ServiceResponse> Create(PostCompanyViewModel viewModel)
    {
        var createCommand = _mapper.Map<CreateCompanyCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(createCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ResponseCompanyViewModel> GetById(Guid companyId)
    => _mapper.Map<ResponseCompanyViewModel>
        (await _companyRepository.GetOneWhere(d => d.Id == companyId));

    public async Task<ServiceResponse> Update(PutCompanyViewModel viewModel)
    {
        var updateCommand = _mapper.Map<UpdateCompanyCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(updateCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }

    public async Task<ServiceResponse> Delete(DeleteCompanyViewModel viewModel)
    {
        var deleteCommand = _mapper.Map<DeleteCompanyCommand>(viewModel);
        var commandResult = await _mediator.SendCommand(deleteCommand);
        return new ServiceResponse(commandResult.Success, commandResult.Response);
    }
}