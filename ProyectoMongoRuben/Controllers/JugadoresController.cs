using Microsoft.AspNetCore.Mvc;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoMongoRuben.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadorService jugadorService;

        public JugadoresController(IJugadorService jugadorService) 
        {
            this.jugadorService = jugadorService;
        }

        // GET: api/<JugadoresController>
        [HttpGet]
        public ActionResult<List<Jugador>>Get()
        {
            return jugadorService.Get();
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public ActionResult<Jugador> Get(string id)
        {
            var jugador = jugadorService.Get(id);

            if (jugador == null)
            {
                return NotFound($"Jugador con la Id = {id} no encontrado");
            }

            return jugador;
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public ActionResult<Jugador> Post([FromBody] Jugador jugador)
        {
            jugadorService.Create(jugador);
            return CreatedAtAction(nameof(Get), new { id = jugador.Id }, jugador);
        }

        // PUT api/<JugadoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Jugador jugador)
        {
            var jugadorExistente = jugadorService.Get(id);

            if (jugadorExistente == null)
            {
                return NotFound($"El estudiante con la Id = {id} no se encontro");
            }

            jugadorService.Update(id, jugador);

            return NoContent(); 
        }

        // DELETE api/<JugadoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var jugador = jugadorService.Get(id);
            //if (jugador == null) 
            //{
            //    return NotFound($"El estudiante con la Id = {id} no se encontro");
            //}

            jugadorService.Remove(jugador.Id);
            return Ok($"El jugador con Id = {id} ha sido eliminado");
        }
    }
}
