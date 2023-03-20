using ProyectoMongoRuben.Models;
using MongoDB.Driver;
namespace ProyectoMongoRuben.Services
{
    public class JugadorService : IJugadorService
    {
        private readonly IMongoCollection<Jugador> _jugadores;

        public JugadorService(ITerrariaStoreDatabaseSettings settings, IMongoClient mongoClient)  
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _jugadores = database.GetCollection<Jugador>(settings.TerrariaJugadorCollectionName);
        }
        public Jugador Create(Jugador jugador)
        {
            _jugadores.InsertOne(jugador);
            return jugador;
        }

        public List<Jugador> Get()
        {
            return _jugadores.Find(jugador => true).ToList();
        }

        public Jugador Get(string id)
        {
            return _jugadores.Find(jugador => jugador.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _jugadores.DeleteOne(jugador => jugador.Id == id);
        }

        public void Update(string id, Jugador jugador)
        {
            _jugadores.ReplaceOne(jugador => jugador.Id == id, jugador);
        }
    }
}
