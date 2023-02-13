using EasyDocs.Domain.Core.Interfaces;
using EasyDocs.Domain.Entities;

namespace EasyDocs.Domain.Interfaces
{
    public interface IUserDocumentRepository : IBaseRepository<UserDocument>
    {
        Task<bool> UserDocumentExists(Guid id);
    }
}
