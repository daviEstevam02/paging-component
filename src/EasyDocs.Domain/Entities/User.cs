﻿using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class User : Entity
{
    private User()
	{ }

    public User(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        Guid userTypeId, 
        string linkCode,
        EDocumentGroup documentGroup, 
        Username username, 
        Email email, 
        Password password
        ) : base(id)
    {
        LicenseeId = licenseeId;
        CompanyId = companyId;
        UserTypeId = userTypeId;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        Username = username;
        Email = email;
        Password = password;

        AddNotifications(Username, Email, Password);
    }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid UserTypeId { get; private set; }
    public string LinkCode { get; set; } = string.Empty;
    public EDocumentGroup DocumentGroup { get; private set; }
    public Username Username { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public Licensee Licensee { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
    public UserType UserType { get; private set; } = null!;
    public IList<UserDocument> UserDocuments { get; private set; } = null!;
}