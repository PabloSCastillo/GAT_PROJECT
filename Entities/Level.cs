using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Level
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("idLevel")]
    private ObjectId Id { get; set; }
    [BsonElement("name")]
    private string Name { get; set; }
}