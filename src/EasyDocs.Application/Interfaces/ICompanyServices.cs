using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.Interfaces;

public interface ICompanyServices
{
    Task<IEnumerable<ResponseCompanyViewModel>> GetAll(Guid licenseeId);
    Task<ResponseCompanyViewModel> GetById(Guid companyId);
    Task<ServiceResponse> Create(PostCompanyViewModel viewModel);
    Task<ServiceResponse> Update(PutCompanyViewModel viewModel);
    Task<ServiceResponse> Delete(DeleteCompanyViewModel viewModel);
}