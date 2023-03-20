using ProyectoMongoRuben.Models;

namespace ProyectoMongoRuben.Services
{
    public interface IClaseService
    {
        List<Clase> Get();
        Clase Get(string id);
        Clase Create(Clase clase);
        void Update(string id, Clase clase);
        void Remove(string id);
    }
}
