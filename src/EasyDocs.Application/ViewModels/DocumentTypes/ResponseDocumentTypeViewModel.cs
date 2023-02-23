﻿using EasyDocs.Application.ViewModels.Clients;

namespace EasyDocs.Application.ViewModels.DocumentTypes;

public sealed class ResponseDocumentTypeViewModel
{
    public Guid Id { get; set; }
    public ResponseClientViewModel Client { get; set; }
    public string DocumentGroup { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
}