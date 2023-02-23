using AutoMapper;
using EasyDocs.Application.Helper;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Application.ViewModels.DocumentTypes;
using EasyDocs.Application.ViewModels.Users;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Commands.DocumentTypes;
using EasyDocs.Domain.Commands.Users;

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