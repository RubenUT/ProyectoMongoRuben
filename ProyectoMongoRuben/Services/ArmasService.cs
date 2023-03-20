using MongoDB.Driver;
using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public class ArmasService : IArmasService
    {
        private readonly IMongoCollection<Armas> _armas;

        public ArmasService(ITerrariaStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _armas = database.GetCollection<Armas>(settings.TerrariaArmasCollectionName);
        }   
        public Armas Create(Armas armas)
        {
            _armas.InsertOne(armas);
            return armas;
        }

        public List<Armas> Get()
        {
            return _armas.Find(armas => true).ToList();
        }

        public Armas Get(string id)
        {
            return _armas.Find(armas => armas.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _armas.DeleteOne(armas => armas.Id == id);
        }

        public void Update(string id, Armas armas)
        {
            _armas.ReplaceOne(armas => armas.Id == id, armas);
        }
    }
}
