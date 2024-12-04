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
        Task<IEnumerable<TareaMS>> obtenerTareas();
        Task<TareaMS> obtenerTareaPorId(int id);
        Task<bool> crearTarea(TareaME tarea);
        Task<bool> actualizarTarea(TareaME tarea);
        Task<bool> eliminarTarea(TareaME tarea);
    }

}
