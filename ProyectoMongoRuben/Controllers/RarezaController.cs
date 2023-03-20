using Microsoft.AspNetCore.Mvc;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoMongoRuben.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RarezaController : ControllerBase
    {
        private readonly IRarezaService RarezaService;

        public RarezaController(IRarezaService RarezaService)
        {
            this.RarezaService = RarezaService;
        }

        // GET: api/<RarezaController>
        [HttpGet]
        public ActionResult<List<Rareza>> Get()
        {
            return RarezaService.Get();
        }

        // GET api/<RarezaController>/5
        [HttpGet("{id}")]
        public ActionResult<Rareza> Get(string id)
        {
            var rareza = RarezaService.Get(id);

            if (rareza == null)
            {
                return NotFound($"Rareza con la Id = {id} no encontrado");
            }

            return rareza;
        }

        // POST api/<RarezaController>
        [HttpPost]
        public ActionResult<Rareza> Post([FromBody] Rareza rareza)
        {
            RarezaService.Create(rareza);
            return CreatedAtAction(nameof(Get), new { id = rareza.Id }, rareza);
        }

        // PUT api/<RarezaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Rareza rareza)
        {
            var rarezaExistente = RarezaService.Get(id);

            if (rarezaExistente == null)
            {
                return NotFound($"La rareza con Id = {id} no se encontro");
            }

            RarezaService.Update(id, rareza);

            return NoContent();
        }

        // DELETE api/<RarezaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var rareza = RarezaService.Get(id);

            RarezaService.Remove(rareza.Id);
            return Ok($"La rareza con Id = {id} ha sido eliminado");
        }
    }
}
