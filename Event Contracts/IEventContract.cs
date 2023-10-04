using EventConcern;

namespace EventContracts
{
    public interface IEventContract
    {
        Event AddEvent(Event newEvent);

        Event? UpdateEvent(Event updatedEvent);

        List<Event> GetAll();

        Event GetEvent(string id);

        bool DeleteEvent(string id);
    }
}