using ApiTareas.Model;

namespace ApiTareas.Data.Repositories
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<ComentarioMS>> obtenerComentarios();
        Task<IEnumerable<ComentarioMS>> obtenerComentarioPorIdTarea(int idTarea);
        Task<IEnumerable<ComentarioMS>> obtenerComentarioPorIdUsuario(int idUsuario);
        Task<int> crearComentario(ComentarioME comentario);
    }
}
