using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTareas()
        {
            return Ok(await _tareaRepository.obtenerTareas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTareaPorId(int id)
        {
            return Ok(await _tareaRepository.obtenerTareaPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = await _tareaRepository.crearTarea(tarea);

            return Ok("Tarea creada correctamente" + creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tareaRepository.actualizarTarea(tarea);
            return Ok("Tarea actualizada correctamente");
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarTarea(int id)
        {
          
            await _tareaRepository.eliminarTarea(new Tarea { Id =id});
            return NoContent();
        }
    }
}
