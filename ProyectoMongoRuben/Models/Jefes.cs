using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoRuben.Models
{
    public class Jefes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("nombre")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("vida")]
        public int Vida { get; set; }

        [BsonElement("daño")]
        public int Daño { get; set; }
    }
}
