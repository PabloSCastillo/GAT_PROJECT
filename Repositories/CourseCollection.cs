using GAT_PROJECT.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GAT_PROJECT.Repositories
{
    public class CourseCollection : ICourseCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Course> Collection; public CourseCollection()
        {
            Collection = _repository.db.GetCollection<Course>("Courses");
        }

        public async Task DeleteCourse(string id)
        {
            var filter = Builders<Course>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Course> GetCourseById(string id)
        {
            return await Collection.FindAsync(
              new BsonDocument { { "_id", new ObjectId()} }).Result.FirstAsync();
        }

        public async Task InsertCourse(Course course)
        {
            await Collection.InsertOneAsync(course);
        }

        public async Task UpdateCourse(Course course)
        {
            var filter = Builders<Course>
                .Filter
                .Eq(s => s.Id, course.Id);
            await Collection.ReplaceOneAsync(filter, course);
        }
    }
}
