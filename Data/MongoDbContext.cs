using MongoDB.Bson;
using MongoDB.Driver;

namespace Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var connectionString = "mongodb://localhost:27017/TasksCounting";
            var databaseName = "TasksCounting";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<BsonDocument> TasksCollection
        {
            get
            {
                return _database.GetCollection<BsonDocument>("Tasks");
            }
        }
    }
}