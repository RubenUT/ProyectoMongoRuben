using Microsoft.AspNetCore.Mvc;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoMongoRuben.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmasController : ControllerBase
    {
        private readonly IArmasService ArmasService;
        public ArmasController(IArmasService ArmasService) 
        { 
            this.ArmasService = ArmasService;
        }
        // GET: api/<ArmasController>
        [HttpGet]
        public ActionResult<List<Armas>> Get()
        {
            return ArmasService.Get();
        }

        // GET api/<ArmasController>/5
        [HttpGet("{id}")]
        public ActionResult<Armas> Get(string id)
        {
            var arma = ArmasService.Get(id);

            if (arma == null)
            {
                return NotFound($"Jugador con la Id = {id} no encontrado");
            }

            return arma;
        }

        // POST api/<ArmasController>
        [HttpPost]
        public ActionResult<Armas> Post([FromBody] Armas armas)
        {
            ArmasService.Create(armas);
            return CreatedAtAction(nameof(Get), new { id = armas.Id }, armas);
        }

        // PUT api/<ArmasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Armas armas)
        {
            var armaExistente = ArmasService.Get(id);

            if (armaExistente == null)
            {
                return NotFound($"El arma con Id = {id} no se encontro");
            }

            ArmasService.Update(id, armas);

            return NoContent();
        }

        // DELETE api/<ArmasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var armas = ArmasService.Get(id);
            //if (jugador == null) 
            //{
            //    return NotFound($"El estudiante con la Id = {id} no se encontro");
            //}

            ArmasService.Remove(armas.Id);
            return Ok($"El arma con Id = {id} ha sido eliminado");
        }
    }
}
