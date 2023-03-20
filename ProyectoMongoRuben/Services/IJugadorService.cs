using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public interface IJugadorService
    {
        List<Jugador> Get();
        Jugador Get(string id);
        Jugador Create(Jugador jugador);
        void Update(string id, Jugador jugador);
        void Remove(string id);
    }
}
