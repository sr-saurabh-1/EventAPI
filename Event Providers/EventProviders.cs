using Event_Concerns;
using Event_Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Event_Providers
{
    public class EventProviders : IEventContracts
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "EventDb";
        private const string CollectionName = "Events";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public void AddEvent(EventConcerns eventConCerns)
        {
            var eventsCollection = ConnectToMongo<EventConcerns>(CollectionName);
            BsonObjectId bsonObjectId = ObjectId.GenerateNewId();
            eventConCerns.EventId = bsonObjectId.ToString();
            eventsCollection.InsertOne(eventConCerns);
        }

        public EventConcerns GetEventById(string id)
        {
            var eventsCollection = ConnectToMongo<EventConcerns>(CollectionName);
            var results = eventsCollection.Find(e => e.EventId == id).ToList();
            return results[0];
        }

        public List<EventConcerns> GetEvents()
        {
            var eventsCollection = ConnectToMongo<EventConcerns>(CollectionName);
            var results = eventsCollection.Find(_=>true).ToList();
            return results;
        }

        public EventConcerns? UpdateEvent(EventConcerns eventConCerns)
        {
            var eventsCollection = ConnectToMongo<EventConcerns>(CollectionName);
            //var filter = Builders<EventConcerns>.Filter.Eq("EventId", eventConCerns.EventId);
            var filter = Builders<EventConcerns>.Filter.Eq(e => e.EventId, eventConCerns.EventId);
            var result = eventsCollection.ReplaceOne(filter, eventConCerns, new ReplaceOptions { IsUpsert = false });
            if (result.MatchedCount == 1 && result.MatchedCount == result.ModifiedCount)
                return eventConCerns;
            else return null;
        }

        public bool DeleteEvent(string id)
        {
            var eventsCollection = ConnectToMongo<EventConcerns>(CollectionName);

            var deleteFilter = Builders<EventConcerns>.Filter.Eq(e => e.EventId, id);
            var res = eventsCollection.DeleteOne(deleteFilter);
            if (res.DeletedCount == 1)
                return true;
            else return false;
            
        }
    }
}