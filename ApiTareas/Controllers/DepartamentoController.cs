using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDepartamentos()
        {
            return Ok(await _departamentoRepository.obtenerDepartamentos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerDepartamentoPorId(int id)
        {
            return Ok(await _departamentoRepository.obtenerDepartamentoPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearDepartamento([FromBody] Departamento departamento)
        {
            if (departamento == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = await _departamentoRepository.crearDepartamento(departamento);

            return Ok("Departamento creado correctamente" + creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarDepartamento([FromBody] Departamento departamento)
        {
            if (departamento == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _departamentoRepository.actualizarDepartamento(departamento);
            return Ok("Departamento actualizado correctamente");
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarDepartamento( int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _departamentoRepository.eliminarDepartamento(new Departamento { Id= id});
            return NoContent();
        }
    }
}
