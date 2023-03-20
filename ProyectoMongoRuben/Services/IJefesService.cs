using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public interface IJefesService
    {
        List<Jefes> Get();
        Jefes Get(string id);
        Jefes Create(Jefes jefes);
        void Update(string id, Jefes jefes);
        void Remove(string id);
    }
}
