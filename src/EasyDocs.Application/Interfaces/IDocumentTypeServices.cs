using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.DocumentTypes;

namespace EasyDocs.Application.Interfaces;

public interface IDocumentTypeServices
{
    Task<IEnumerable<ResponseDocumentTypeViewModel>> GetAll(Guid companyId);
    Task<ResponseDocumentTypeViewModel> GetById(Guid documentTypeId);

    Task<ServiceResponse> Create(PostDocumentTypeViewModel viewModel);
    Task<ServiceResponse> Update(PutDocumentTypeViewModel viewModel);
    Task<ServiceResponse> Delete(DeleteDocumentTypeViewModel viewModel);
}