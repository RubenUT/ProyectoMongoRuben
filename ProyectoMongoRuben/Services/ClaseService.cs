using MongoDB.Driver;
using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{

    public class ClaseService : IClaseService
    {
        private readonly IMongoCollection<Clase> _clase;

        public ClaseService(ITerrariaStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _clase = database.GetCollection<Clase>(settings.TerrariaClasesCollectionName);
        }
        public Clase Create(Clase clase)
        {
            _clase.InsertOne(clase);
            return clase;
        }

        public List<Clase> Get()
        {
            return _clase.Find(clase => true).ToList();
        }

        public Clase Get(string id)
        {
            return _clase.Find(clase => clase.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _clase.DeleteOne(clase => clase.Id == id);
        }

        public void Update(string id, Clase clase)
        {
            _clase.ReplaceOne(clase => clase.Id == id, clase);
        }
    }
}
