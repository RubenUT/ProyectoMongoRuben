using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public interface IRarezaService
    {
        List<Rareza> Get();
        Rareza Get(string id);
        Rareza Create(Rareza rareza);
        void Update(string id, Rareza rareza);
        void Remove(string id);
    }
}
