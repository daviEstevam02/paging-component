﻿using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> UserExists(Guid id);
}