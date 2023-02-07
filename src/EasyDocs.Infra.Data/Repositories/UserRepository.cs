﻿using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(EasyDocsContext context)
        : base(context)
    { }

    public async Task<bool> UserExists(Guid id)
        => await GetOneWhere(user => user.Id == id) is not null;
}