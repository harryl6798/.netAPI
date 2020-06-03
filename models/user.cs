using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace harry.Models
{   
    [BsonIgnoreExtraElements] 
    public class user
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        public string word { get; set; }


    }
}