using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IEstadoTareaRepository
    {
        Task<IEnumerable<EstadoTarea>> obtenerEstadoTareas();
        Task<EstadoTarea> obtenerEstadoTareaPorId(int id);
        Task<bool> crearEstadoTarea(EstadoTarea estado);
        Task<bool> actualizarEstadoTarea(EstadoTarea estado);
        Task<bool> eliminarEstadoTarea(EstadoTarea estado);
    }
}
