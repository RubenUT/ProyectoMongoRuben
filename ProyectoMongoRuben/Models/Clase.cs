using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProyectoMongoRuben.Models
{
    public class Clase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("nombre")]
        public string Name { get; set; } = String.Empty;
    }
}
