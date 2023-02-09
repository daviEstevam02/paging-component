using AutoMapper;
using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Commands.DocumentTypes;

namespace EasyDocs.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
	public ViewModelToDomainProfile()
	{
        #region Documents
        CreateMap<PostDocumentViewModel, CreateDocumentCommand>()
			.ConstructUsing(viewModel => new CreateDocumentCommand(
                viewModel.LicenseeId,
                viewModel.CompanyId,
                viewModel.DocumentTypeId,
                viewModel.Description,
                viewModel.Source,
                viewModel.ExpirationDate,
                viewModel.File,
                viewModel.SpecificAccess,
                viewModel.UserId)
            );
        #endregion

        #region Companies
        CreateMap<PostCompanyViewModel, CreateCompanyCommand>()
            .ConstructUsing(viewModel => new CreateCompanyCommand(
                viewModel.LicenseeId,
                viewModel.FantasyName,
                viewModel.LegalName,
                viewModel.Country,
                viewModel.State,
                viewModel.City,
                viewModel.Neighborhood,
                viewModel.Street,
                viewModel.Number,
                viewModel.Compliment,
                viewModel.Contact,
                viewModel.Cnpj,
                viewModel.IsHeadquarter,
                viewModel.UserId)
            );
        #endregion

        #region DocumentTypes
        CreateMap<PostDocumentTypeViewModel, CreateDocumentTypeCommand>()
           .ConstructUsing(viewModel => new CreateDocumentTypeCommand(
               viewModel.LicenseeId,
               viewModel.CompanyId,
               viewModel.DocumentGroup,
               viewModel.Description,
               viewModel.UserId)
           );

        CreateMap<PutDocumentTypeViewModel, UpdateDocumentTypeCommand>()
           .ConstructUsing(viewModel => new UpdateDocumentTypeCommand(
               viewModel.Id,
               viewModel.LicenseeId,
               viewModel.CompanyId,
               viewModel.DocumentGroup,
               viewModel.Description,
               viewModel.UserId)
           );

        CreateMap<DeleteDocumentTypeViewModel, DeleteDocumentTypeCommand>()
          .ConstructUsing(viewModel => new DeleteDocumentTypeCommand(
              viewModel.Id,
              viewModel.UserId)
          );
        #endregion
    }
}