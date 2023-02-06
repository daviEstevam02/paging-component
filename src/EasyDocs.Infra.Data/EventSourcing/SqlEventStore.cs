using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Interfaces;

namespace EasyDocs.Infra.Data.EventSourcing;

public class SqlEventStore : IEventStore
{
    private readonly IEventStoreRepository _eventStoreRepository;
    private readonly IUserRepository _userRepository;

    public SqlEventStore(IEventStoreRepository eventStoreRepository, IUserRepository userRepository)
    {
        _eventStoreRepository = eventStoreRepository;
        _userRepository = userRepository;
    }

    public async Task Save<T>(T theEvent) where T : Event
    {
        var userExists = await _userRepository.GetOneWhere(u => u.Id == theEvent.UserId);

        if (userExists is null) throw new InvalidDataException("Usuário inexistente.");

        var storedEvent = new StoredEvent(
            theEvent,
            userExists.Username.ToString()!);

        _eventStoreRepository.Store(storedEvent);
    }
}