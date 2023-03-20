using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public interface IArmasService
    {
        List<Armas> Get();
        Armas Get(string id);
        Armas Create(Armas armas);
        void Update(string id, Armas armas);
        void Remove(string id);
    }
}
