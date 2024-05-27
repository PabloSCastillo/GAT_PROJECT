using MongoDB.Bson;

namespace GAT_PROJECT.Entities
{
    public class Course
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string level { get; set; }


    }
}
