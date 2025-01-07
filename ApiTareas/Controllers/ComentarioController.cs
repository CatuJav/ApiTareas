using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        [HttpGet("comentarioTarea")]
        public async Task<IActionResult> ObtenerComentariosPorTarea(int idTarea)
        {
            return Ok(await _comentarioRepository.obtenerComentarioPorIdTarea(idTarea));
        }

        [HttpGet("comentarioUsuario")]
        public async Task<IActionResult> ObtenerComentariosPorUsuario(int idUsuario)
        {
            return Ok(await _comentarioRepository.obtenerComentarioPorIdUsuario(idUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> CrearComentario([FromBody] ComentarioME comentario)
        {
            if (comentario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int creado = await _comentarioRepository.crearComentario(comentario);

            return Ok(creado);
        }



    }
}
