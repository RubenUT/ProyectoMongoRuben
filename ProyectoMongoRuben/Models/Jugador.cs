using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoRuben.Models
{
    public class Jugador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("nombre")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("vida")]
        public int Vida { get; set; }

        [BsonElement("clase")]
        public string Clase { get; set; } = String.Empty;
    }
}
