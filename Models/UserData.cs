using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace corewebapi.Model
{
    public class UserData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        
        public string Name { get; set; } = null!;


        public string EmailID { get; set; } = null!;
        public string LoginID { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
