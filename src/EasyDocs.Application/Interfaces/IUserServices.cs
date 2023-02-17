using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Users;

namespace EasyDocs.Application.Interfaces;

public interface IUserServices
{
    Task<IEnumerable<ResponseUserViewModel>> GetAll(Guid companyId);
    Task<ResponseUserViewModel> GetById(Guid userId);

    Task<ServiceResponse> Login(string email, string password);
    Task<ServiceResponse> Create(PostUserViewModel viewModel);
    Task<ServiceResponse> Update(PutUserViewModel viewModel);
    Task<ServiceResponse> Delete(DeleteUserViewModel viewModel);
}