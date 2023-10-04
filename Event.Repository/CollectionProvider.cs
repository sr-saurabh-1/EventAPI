using MongoDB.Driver;

namespace EventRepository
{
    public static class CollectionProvider
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "EventDb";
        private const string CollectionName = "Events";

        public static IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}