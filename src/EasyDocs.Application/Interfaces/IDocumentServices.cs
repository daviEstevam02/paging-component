using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Documents;

namespace EasyDocs.Application.Interfaces;

public interface IDocumentServices
{
    Task<ServiceResponse> Create(PostDocumentViewModel viewModel);
}