using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces;

public interface IUserTypeRepository : IBaseRepository<UserType>
{
    Task<bool> UserTypeExists(Guid userTypeId);
}