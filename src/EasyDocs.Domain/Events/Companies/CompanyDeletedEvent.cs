using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.Companies
{
   public sealed class CompanyDeletedEvent : Event
    {
        public CompanyDeletedEvent(
        Guid id,
        Guid userId,
        string username
    ) : base(EAction.Deleted, userId, username, EntitiesContexts.COMPANIES)

      {
            Id = id;
            AggregateId = id;
      }
        public Guid Id { get; private set; }
    }
}
