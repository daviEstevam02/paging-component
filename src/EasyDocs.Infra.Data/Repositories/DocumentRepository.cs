using EasyDocs.Domain.Entities;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Core;

namespace EasyDocs.Infra.Data.Repositories;

public sealed class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(EasyDocsContext context) 
        : base(context)
    { }
}