using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<bool> ClientExists(Guid clientId);
}