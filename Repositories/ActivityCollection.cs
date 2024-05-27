using GAT_PROJECT.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GAT_PROJECT.Repositories
{
    public class ActivityCollection : IActivityCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Activity> Collection;
        public ActivityCollection() 
        {
            Collection = _repository.db.GetCollection<Activity>("Avtivities");
        }
        public async Task DeleteActivity(string id)
        {
            var filter = Builders<Activity>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Activity> GetAcivityById(string id)
        {
            return await Collection.FindAsync(
                
                new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertActivity(Activity activity)
        {
            await Collection.InsertOneAsync(activity);
        }

        public async Task UpdateActivity(Activity activity)
        {
            var filter = Builders<Activity>
                .Filter
                .Eq(s => s.Id, activity.Id);
            await Collection.ReplaceOneAsync(filter, activity);
        }
    }
}
