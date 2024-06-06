using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GAT_PROJECT.Entities
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("idCourse")]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
      
        [BsonElement("idLevel")]
     
        public Level Difficult { get; set; }


    }
}
