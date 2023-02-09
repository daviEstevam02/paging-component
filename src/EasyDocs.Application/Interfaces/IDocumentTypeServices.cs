using EasyDocs.Application.Core;
using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.Interfaces;

public interface IDocumentTypeServices
{
    Task<ServiceResponse> Create(PostDocumentTypeViewModel viewModel);
}