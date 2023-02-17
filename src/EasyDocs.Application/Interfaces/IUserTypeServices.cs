using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.UserTypes;

namespace EasyDocs.Application.Interfaces;

public interface IUserTypeServices
{
    Task<IEnumerable<ResponseUserTypeViewModel>> GetAll(Guid companyId);
    Task<ResponseUserTypeViewModel> GetById(Guid userTypeId);

    Task<ServiceResponse> Create(PostUserTypeViewModel viewModel);
    Task<ServiceResponse> Update(PutUserTypeViewModel viewModel);
    Task<ServiceResponse> Delete(DeleteUserTypeViewModel viewModel);
}