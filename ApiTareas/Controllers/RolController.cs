using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRoles()
        {
            return Ok(await _rolRepository.obtenerRoles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtnerRolPorId(int id)
        {
            return Ok(await _rolRepository.obtenerRolesPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] Rol rol)
        {
            if(rol == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = await _rolRepository.crearRol(rol);

            return Ok("Rol creado correctamente"+creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarRol([FromBody] Rol rol)
        {
            if(rol == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           await _rolRepository.actualizarRol(rol);

            return NoContent();

        }

        [HttpDelete]

        public async Task<IActionResult> EliminarRol(int id)
        {
            await _rolRepository.eliminarRol(new Rol {Id = id });

            return NoContent();
        }
}
}
