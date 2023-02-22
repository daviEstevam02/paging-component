using AutoMapper;
using EasyDocs.Application.Helper;
using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Application.ViewModels.Users;
using EasyDocs.Application.ViewModels.UserTypes;
using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Commands.Users;
using EasyDocs.Domain.Commands.UserTypes;

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
                FormFileExtensions.GetBytes(viewModel.File),
                viewModel.SpecificAccess,
                viewModel.UserId)
            );

        CreateMap<PutDocumentViewModel, UpdateDocumentCommand>()
            .ConstructUsing(viewModel => new UpdateDocumentCommand(
                viewModel.Id,
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

        CreateMap<DeleteDocumentViewModel, DeleteDocumentCommand>()
           .ConstructUsing(viewModel => new DeleteDocumentCommand(
               viewModel.Id,
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

        #region UserTypes
        CreateMap<PostUserTypeViewModel, CreateUserTypeCommand>()
          .ConstructUsing(viewModel => new CreateUserTypeCommand(
              viewModel.LicenseeId,
              viewModel.CompanyId,
              viewModel.ErpUserType,
              viewModel.Description,
              viewModel.CanRead,
              viewModel.CanWrite,
              viewModel.CanUpdate,
              viewModel.CanDelete,
              viewModel.UserId)
          );

        CreateMap<PutUserTypeViewModel, UpdateUserTypeCommand>()
           .ConstructUsing(viewModel => new UpdateUserTypeCommand(
               viewModel.Id,
               viewModel.LicenseeId,
               viewModel.CompanyId,
               viewModel.ErpUserType,
               viewModel.Description, 
               viewModel.CanRead,
               viewModel.CanWrite,
               viewModel.CanUpdate,
               viewModel.CanDelete,
               viewModel.UserId)
           );

        CreateMap<DeleteUserTypeViewModel, DeleteUserTypeCommand>()
          .ConstructUsing(viewModel => new DeleteUserTypeCommand(
              viewModel.Id,
              viewModel.UserId)
          );
        #endregion

        #region Users
        CreateMap<PostUserViewModel, CreateUserCommand>()
         .ConstructUsing(viewModel => new CreateUserCommand(
             viewModel.LicenseeId,
             viewModel.CompanyId,
             viewModel.UserTypeId,
             viewModel.LinkCode,
             viewModel.DocumentGroup,
             viewModel.Username,
             viewModel.Email,
             viewModel.Password,
             viewModel.UserId)
         );

        CreateMap<PutUserViewModel, UpdateUserCommand>()
           .ConstructUsing(viewModel => new UpdateUserCommand(
               viewModel.Id,
               viewModel.LicenseeId,
               viewModel.CompanyId,
               viewModel.UserTypeId,
               viewModel.LinkCode,
               viewModel.DocumentGroup,
               viewModel.Username,
               viewModel.Email,
               viewModel.Password,
               viewModel.UserId)
           );

        CreateMap<DeleteUserViewModel, DeleteUserCommand>()
          .ConstructUsing(viewModel => new DeleteUserCommand(
              viewModel.Id,
              viewModel.UserId)
          );
        #endregion
    }
}