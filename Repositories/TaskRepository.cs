using Data;
using Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class TaskRepository
    {
        private readonly MongoDbContext _context;

        public TaskRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task IncrementNumberAsync()
        {
            var update = Builders<BsonDocument>.Update.Inc("Number", 1);
            await _context.TasksCollection.UpdateOneAsync(_ => true, update);
        }

        public async Task<int> GetNumberAsync()
        {
            var task = await _context.TasksCollection.Find(_ => true).FirstOrDefaultAsync();
            if (task != null && task.Contains("Number"))
            {
                return task["Number"].AsInt32;
            }
            return 0; // Return 0 if the "Number" field is not found
        }
    }
}