using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GAT_PROJECT.Entities
{
    public class Course
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("level")]
        public string level { get; set; }


    }
}
