using Microsoft.AspNetCore.Mvc;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoMongoRuben.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JefesController : ControllerBase
    {
        private readonly IJefesService jefesService;

        public JefesController(IJefesService jefesService)
        {
            this.jefesService = jefesService;
        }
        // GET: api/<JefesController>
        [HttpGet]
        public ActionResult<List<Jefes>> Get()
        {
            return jefesService.Get();
        }

        // GET api/<JefesController>/5
        [HttpGet("{id}")]
        public ActionResult<Jefes> Get(string id)
        {
            var jefes = jefesService.Get(id);

            if (jefes == null)
            {
                return NotFound($"Jefe con la Id = {id} no encontrado");
            }

            return jefes;
        }

        // POST api/<JefesController>
        [HttpPost]
        public ActionResult<Jefes> Post([FromBody] Jefes jefes)
        {
            jefesService.Create(jefes);
            return CreatedAtAction(nameof(Get), new { id = jefes.Id }, jefes);
        }

        // PUT api/<JefesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Jefes jefes)
        {
            var jefeExistente = jefesService.Get(id);

            if (jefeExistente == null)
            {
                return NotFound($"El jefe con la Id = {id} no se encontro");
            }

            jefesService.Update(id, jefes);

            return NoContent();
        }

        // DELETE api/<JefesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var jefes = jefesService.Get(id);

            jefesService.Remove(jefes.Id);
            return Ok($"El jugador con Id = {id} ha sido eliminado");
        }
    }
}
