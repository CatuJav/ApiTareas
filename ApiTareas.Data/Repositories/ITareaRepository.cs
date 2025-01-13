using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface ITareaRepository
    {
        Task<IEnumerable<TareaResumenMS>> obtenerTareas();
        Task<TareaMS> obtenerTareaPorId(int id);
        Task<int> crearTarea(TareaME tarea);
        Task<bool> actualizarTarea(TareaME tarea);
        Task<bool> actualizarProgresoTarea(TareaProgresoME id);
        Task<bool> eliminarTarea(TareaME tarea);
        Task<IEnumerable<TareaUsuarioMS>> tareaUsuarios(int idTarea);
    }

}
