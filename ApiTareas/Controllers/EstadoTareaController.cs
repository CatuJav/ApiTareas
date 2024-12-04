using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoTareaController : ControllerBase
    {
        private readonly IEstadoTareaRepository _estadoTareaRepository;

        public EstadoTareaController(IEstadoTareaRepository estadoTareaRepository)
        {
            _estadoTareaRepository = estadoTareaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEstadoTareas()
        {
            return Ok(await _estadoTareaRepository.obtenerEstadoTareas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEstadoTareaPorId(int id)
        {
            return Ok(await _estadoTareaRepository.obtenerEstadoTareaPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearEstadoTarea([FromBody] EstadoTarea estado)
        {
            if (estado == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = await _estadoTareaRepository.crearEstadoTarea(estado);

            return Ok("Estado de tarea creado correctamente" + creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarEstadoTarea([FromBody] EstadoTarea estado)
        {
            if (estado == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _estadoTareaRepository.actualizarEstadoTarea(estado);
            return Ok("Estado de tarea actualizado correctamente");
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarEstadoTarea(int id)
        {
        await _estadoTareaRepository.eliminarEstadoTarea(new EstadoTarea { Id = id });
            return NoContent();
        }
        }
        }
