using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            return Ok(await _usuarioRepository.obtenerUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            return Ok(await _usuarioRepository.obtenerUsuariosPorId(id));
        }

        [HttpGet("nombre/{usuario}")]
        public async Task<IActionResult> ObtenerUsuarioPorNombre(string usuario)
        {
            return Ok(await _usuarioRepository.obtenerUnoUsuarioPorNombre(usuario));
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioME usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = await _usuarioRepository.crearUsuario(usuario);

            return Ok("Usuario creado correctamente"+creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] UsuarioME usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actualizado = await _usuarioRepository.actualizarUsuario(usuario);

            return Ok("Usuario actualizado correctamente"+actualizado);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario([FromBody] UsuarioME usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eliminado = await _usuarioRepository.eliminarUsuario(usuario);

            return Ok("Usuario eliminado correctamente"+eliminado);
        }
    }
}
