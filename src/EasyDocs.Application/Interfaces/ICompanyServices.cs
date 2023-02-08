using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.Interfaces;

public interface ICompanyServices
{
    Task<IEnumerable<ResponseCompanyViewModel>> GetAll(Guid licenseeId);
    Task<ServiceResponse> Create(PostCompanyViewModel viewModel);
}