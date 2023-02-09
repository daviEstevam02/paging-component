﻿using EasyDocs.Domain.Enums;

namespace EasyDocs.Application.ViewModels.DocumentTypes;

public sealed class PutDocumentTypeViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid CompanyId { get; set; }
    public EDocumentGroup DocumentGroup { get; set; }
    public string Description { get; set; } = string.Empty;
}