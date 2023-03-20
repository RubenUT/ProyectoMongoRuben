using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoRuben.Models
{
    public class Armas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("nombre")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("nivel_rareza")]
        public int Nivel { get; set; }
    }
}
