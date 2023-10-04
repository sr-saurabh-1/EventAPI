using EventConcern;
namespace EventRepository.Contracts
{
    public interface IRepositoryContract
    {
        Event AddEvent(Event newEvent);

        Event? UpdateEvent(Event updatedEvent);

        List<Event> GetAll();

        Event GetEvent(string id);

        bool DeleteEvent(string id);
    }
}
