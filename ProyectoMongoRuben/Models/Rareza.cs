using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoRuben.Models
{
    public class Rareza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("nivel")]
        public int Nivel { get; set; }
        [BsonElement("color")]
        public string Color { get; set; } = String.Empty;
    }
}
