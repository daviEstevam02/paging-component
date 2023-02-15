using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.UserDocuments;

namespace EasyDocs.Application.Interfaces
{
    public interface IUserDocumentServices
    {
        Task<IEnumerable<ResponseUserDocumentViewModel>> GetAll(Guid companyId);
        Task<ResponseUserDocumentViewModel> GetById(Guid userDocumentId);

        Task<ServiceResponse> Create(PostUserDocumentViewModel viewModel);
        Task<ServiceResponse> Update(PutUserDocumentViewModel viewModel);
        Task<ServiceResponse> Delete(DeleteUserDocumentViewModel viewModel);
    }
}
