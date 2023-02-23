using AutoMapper;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Application.ViewModels.Users;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Application.AutoMapper;

public sealed class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        #region DocumentTypes
        CreateMap<DocumentType, ResponseDocumentTypeViewModel>();
        CreateMap<DocumentType, ResponseDocumentTypeDocumentViewModel>();
        #endregion

        #region Documents
        CreateMap<Document, ResponseAllDocumentViewModel>();
        CreateMap<Document, ResponseOneDocumentViewModel>();
        #endregion

        #region Users
        CreateMap<User, ResponseUserViewModel>();
        CreateMap<User, ResponseLoginViewModel>()
            .ForMember(v => v.Token, opt => opt.Ignore());
        #endregion
    }
}