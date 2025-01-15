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
        private readonly IArchivoRepository _archivoRepository;

        public TareaController(ITareaRepository tareaRepository, IArchivoRepository archivoRepository)
        {
            _tareaRepository = tareaRepository;
            _archivoRepository = archivoRepository;
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
        public async Task<IActionResult> CrearTarea([FromBody] TareaME tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int creado = await _tareaRepository.crearTarea(tarea);

            return Ok(creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTarea([FromBody] TareaME tarea)
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

        [HttpPut("progreso")]
        public async Task<IActionResult> ActualizarProgresoTarea([FromBody] TareaProgresoME tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tareaRepository.actualizarProgresoTarea(tarea);
            return Ok("Progreso actualizado correctamente");
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarTarea(int id)
        {

            await _tareaRepository.eliminarTarea(new TareaME { Id = id });
            return NoContent();
        }

        [HttpGet("tareaUsuario")]
        public async Task<IEnumerable<TareaUsuarioMS>> tareaUsuarios(int idTarea)
        {
            return await _tareaRepository.tareaUsuarios(idTarea);
        }

        [HttpPost("subir")]

        public async Task<IActionResult> Upload()
        {
            try
            {
                var formFile = Request.Form.Files[0]; // Obtiene el archivo del formulario
                int idTarea = int.Parse(Request.Form["idTarea"]);

                if (formFile == null || formFile.Length == 0)
                {
                    return BadRequest("No se ha seleccionado ningún archivo.");
                }

                if (formFile.ContentType != "application/pdf")
                {
                    return BadRequest("Solo se aceptan archivos PDF.");
                }

                if (formFile.Length > 10 * 1024 * 1024) // Ejemplo: Limite de 10MB
                {
                    return BadRequest("El archivo excede el tamaño permitido (10MB).");
                }


                using (var memoryStream = new MemoryStream())
                {
                    await formFile.CopyToAsync(memoryStream);
                    var archivo = new Archivo
                    {
                        Nombre = formFile.FileName,
                        Tipo = formFile.ContentType,
                        Datos = memoryStream.ToArray(),
                        IdTarea = idTarea
                    };

                    await _archivoRepository.subir(archivo);


                    return Ok("Archivo subido correctamente.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("firmarPDF")]
        public async Task<IActionResult> FirmarPDF(int idArchivo, string contrasenaFirma, string rutaFirma)
        {
            try
            {
                var ruta = Path.Combine(Directory.GetCurrentDirectory());
                var firmado = await _archivoRepository.firmarPDF(idArchivo, ruta, contrasenaFirma, rutaFirma);

                if (firmado)
                {
                    return Ok("PDF firmado correctamente.");
                }
                else
                {
                    return BadRequest("Error al firmar el PDF.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("subirFirma")]
        public async Task<IActionResult> SubirFirma()
        {
            try
            {
                var formFile = Request.Form.Files[0]; // Obtiene el archivo del formulario

                if (formFile == null || formFile.Length == 0)
                {
                    return BadRequest("No se ha seleccionado ningún archivo.");
                }

                if (formFile.ContentType != "application/pdf")
                {
                    return BadRequest("Solo se aceptan archivos PDF.");
                }

                if (formFile.Length > 10 * 1024 * 1024) // Ejemplo: Limite de 10MB
                {
                    return BadRequest("El archivo excede el tamaño permitido (10MB).");

                }

                string rutaFirma = _archivoRepository.subirFirma(formFile);
                return Ok(rutaFirma);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
