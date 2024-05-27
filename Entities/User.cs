﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GAT_PROJECT.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


    }
}