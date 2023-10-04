using EventConcern;
using EventRepository.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;


namespace EventRepository.Repository
{
    public class Repository : IRepositoryContract
    {
        private const string CollectionName = "Events";

        public Event AddEvent(Event newEvent)
        {
            var eventsCollection = CollectionProvider.ConnectToMongo<Event>(CollectionName);
            eventsCollection.InsertOne(newEvent);
            return newEvent;
        }

        public Event GetEvent(string id)
        {
            var eventsCollection = CollectionProvider.ConnectToMongo<Event>(CollectionName);
            var results = eventsCollection.Find(e => e.Id == id).ToList();
            return results[0];
        }

        public List<Event> GetAll()
        {
            var eventsCollection = CollectionProvider.ConnectToMongo<Event>(CollectionName);
            var results = eventsCollection.Find(_ => true).ToList();
            return results;
        }

        public Event? UpdateEvent(Event updatedEvent)
        {
            var eventsCollection = CollectionProvider.ConnectToMongo<Event>(CollectionName);
            var filter = Builders<Event>.Filter.Eq(e => e.Id, updatedEvent.Id);
            var result = eventsCollection.ReplaceOne(filter, updatedEvent, new ReplaceOptions { IsUpsert = false });
            if (result.MatchedCount == 1 && result.MatchedCount == result.ModifiedCount)
                return updatedEvent;
            else return null;
        }

        public bool DeleteEvent(string id)
        {
            var eventsCollection = CollectionProvider.ConnectToMongo<Event>(CollectionName);
            var deleteFilter = Builders<Event>.Filter.Eq(e => e.Id, id);
            var res = eventsCollection.DeleteOne(deleteFilter);
            if (res.DeletedCount == 1)
                return true;
            else return false;
        }
    }
}
