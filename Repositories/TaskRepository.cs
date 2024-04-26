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

        //Increments the number
        public async Task IncrementNumberAsync()
        {
            var update = Builders<BsonDocument>.Update.Inc("Number", 1);
            await _context.TasksCounting.UpdateOneAsync(_ => true, update);
        }

        //Fetches the number from the database.
        public async Task<int> GetNumberAsync()
        {
            var task = await _context.TasksCounting.Find(_ => true).FirstOrDefaultAsync();
            if (task != null && task.Contains("Number"))
            {
                return task["Number"].AsInt32;
            }
            return -1;
        }
    }
}