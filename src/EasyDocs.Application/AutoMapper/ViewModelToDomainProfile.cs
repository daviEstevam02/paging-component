﻿using AutoMapper;
using EasyDocs.Application.ViewModels.Documents;
using EasyDocs.Domain.Commands.Documents;

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
                viewModel.File,
                viewModel.SpecificAccess,
                viewModel.UserId)
            );
        #endregion
    }
}