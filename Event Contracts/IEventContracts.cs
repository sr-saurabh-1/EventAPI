using Event_Concerns;

namespace Event_Contracts
{
    public interface IEventContracts
    {
        void AddEvent(EventConcerns eventConCerns);
        EventConcerns GetEventById(string id);
        List<EventConcerns >GetEvents();
        EventConcerns UpdateEvent(EventConcerns eventConCerns);
        //EventConcerns DeleteEvent(string id);
        bool DeleteEvent(string id);


    }
}