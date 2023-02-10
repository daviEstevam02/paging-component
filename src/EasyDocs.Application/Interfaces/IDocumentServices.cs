using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Documents;

namespace EasyDocs.Application.Interfaces;

public interface IDocumentServices
{
    Task<IEnumerable<ResponseAllDocumentViewModel>> GetAll(Guid companyId);
    Task<ResponseOneDocumentViewModel> GetById(Guid documentId);

    Task<ServiceResponse> Create(PostDocumentViewModel viewModel);
    Task<ServiceResponse> Update(PutDocumentViewModel viewModel);
    Task<ServiceResponse> Delete(DeleteDocumentViewModel viewModel);
}