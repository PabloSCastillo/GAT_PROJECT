using System.Diagnostics;
using System.Text.Json.Serialization;
using GAT_PROJECT.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace GAT_PROJECT.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int score { get; set; }

        //public List<Course> Courses { set; get; }
        public string ToString()
        {
            return "\nUsername: " + Username + "\n" +
                    "Name: " + Name + "\n" + "Email: " + Email + "\n";
        }


    }
}
