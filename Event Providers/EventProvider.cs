using EventConcern;
using EventContracts;
using EventRepository.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventProviders
{
    public class EventProvider : IEventContract
    {
        IRepositoryContract RepositoryContract;

        public EventProvider(IRepositoryContract RepositoryContract)
        {
            this.RepositoryContract = RepositoryContract;
        }

        public Event AddEvent(Event newEvent)
        {
            BsonObjectId bsonObjectId = ObjectId.GenerateNewId();
            newEvent.Id = bsonObjectId.ToString();
            return RepositoryContract.AddEvent(newEvent); ;
        }

        public Event GetEvent(string id)
        {
            var result = RepositoryContract.GetEvent(id);
            return result;
        }

        public List<Event> GetAll()
        {
            var results = RepositoryContract.GetAll();
            return results;
        }

        public Event? UpdateEvent(Event updatedEvent)
        {
            return RepositoryContract.UpdateEvent(updatedEvent);
        }

        public bool DeleteEvent(string id)
        {
            return RepositoryContract.DeleteEvent(id);
        }
    }
}