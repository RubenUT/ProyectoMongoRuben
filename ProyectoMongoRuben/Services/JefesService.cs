using MongoDB.Driver;
using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public class JefesService : IJefesService
    {
        private readonly IMongoCollection<Jefes> _jefes;

        public JefesService(ITerrariaStoreDatabaseSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _jefes = database.GetCollection<Jefes>(settings.TerrariaJefesCollectionName);
        }
        public Jefes Create(Jefes jefes)
        {
            _jefes.InsertOne(jefes);
            return jefes;
        }

        public List<Jefes> Get()
        {
            return _jefes.Find(jefes => true).ToList();
        }

        public Jefes Get(string id)
        {
            return _jefes.Find(jefes => jefes.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _jefes.DeleteOne(jefes => jefes.Id == id);
        }

        public void Update(string id, Jefes jefes)
        {
            _jefes.ReplaceOne(jefes => jefes.Id == id, jefes);
        }
    }
}
