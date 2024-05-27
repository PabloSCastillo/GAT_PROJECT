using MongoDB.Bson;

namespace GAT_PROJECT.Entities
{
    public class Activity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
       
        public string Description { get; set; }
        public int Point { get; set; }
        public string Level { get; set; }
        
    }
}
