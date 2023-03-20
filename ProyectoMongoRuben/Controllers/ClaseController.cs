using Microsoft.AspNetCore.Mvc;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoMongoRuben.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClaseService ClaseService;

        public ClaseController(IClaseService ClaseService) 
        {
            this.ClaseService = ClaseService;
        }
        // GET: api/<ClaseController>
        [HttpGet]
        public ActionResult<List<Clase>> Get()
        {
            return ClaseService.Get();
        }

        // GET api/<ClaseController>/5
        [HttpGet("{id}")]
        public ActionResult<Clase> Get(string id)
        {
            var clase = ClaseService.Get(id);

            if (clase == null)
            {
                return NotFound($"Clase con Id = {id} no encontrado");
            }

            return clase;
        }

        // POST api/<ClaseController>
        [HttpPost]
        public ActionResult<Clase> Post([FromBody] Clase clase)
        {
            ClaseService.Create(clase);
            return CreatedAtAction(nameof(Get), new { id = clase.Id }, clase);
        }

        // PUT api/<ClaseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Clase clase)
        {
            var claseExistente = ClaseService.Get(id);

            if (claseExistente == null)
            {
                return NotFound($"La clase con Id = {id} no se encontro");
            }

            ClaseService.Update(id, clase);

            return NoContent();
        }

        // DELETE api/<ClaseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var clase = ClaseService.Get(id);
            ClaseService.Remove(clase.Id);
            return Ok($"La clase con Id = {id} ha sido eliminada");
        }
    }
}
