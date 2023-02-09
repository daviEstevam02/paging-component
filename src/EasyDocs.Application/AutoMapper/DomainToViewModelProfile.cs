using AutoMapper;
using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Application.ViewModels.Licensees;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Application.AutoMapper;

public sealed class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        #region Companies
        CreateMap<Company, ResponseCompanyViewModel>()
            .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Address.Country))
            .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Neighborhood, opts => opts.MapFrom(src => src.Address.Neighborhood))
            .ForMember(dest => dest.Street, opts => opts.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.Compliment, opts => opts.MapFrom(src => src.Address.Compliment))
            .ForMember(dest => dest.Number, opts => opts.MapFrom(src => src.Address.Number));
        #endregion

        #region Licensees
        CreateMap<Licensee, ResponseLicenseeViewModel>();
        #endregion

        #region DocumentTypes
        CreateMap<DocumentType, ResponseDocumentTypeViewModel>();
        #endregion
    }
}