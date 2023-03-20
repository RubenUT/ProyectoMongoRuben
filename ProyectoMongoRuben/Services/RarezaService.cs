using MongoDB.Driver;
using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public class RarezaService : IRarezaService
    {
        private readonly IMongoCollection<Rareza> _rareza;

        public RarezaService(ITerrariaStoreDatabaseSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _rareza = database.GetCollection<Rareza>(settings.TerrariaRarezaCollectionName);
        }
        public Rareza Create(Rareza rareza)
        {
            _rareza.InsertOne(rareza);
            return rareza;
        }

        public List<Rareza> Get()
        {
            return _rareza.Find(rareza => true).ToList();
        }

        public Rareza Get(string id)
        {
            return _rareza.Find(rareza => rareza.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _rareza.DeleteOne(rareza => rareza.Id == id);
        }

        public void Update(string id, Rareza rareza)
        {
            _rareza.ReplaceOne(rareza => rareza.Id == id, rareza);
        }
    }
}
