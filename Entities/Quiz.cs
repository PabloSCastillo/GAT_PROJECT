using MongoDB.Bson;

namespace GAT_PROJECT.Entities
{
    public class Quiz
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
