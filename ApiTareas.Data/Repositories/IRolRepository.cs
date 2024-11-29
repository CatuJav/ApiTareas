using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> obtenerRoles();
        Task<Rol> obtenerRolesPorId(int id);
        Task<bool> crearRol(Rol role);
        Task<bool> actualizarRol(Rol role);
        Task<bool> eliminarRol(Rol role);
    }
}
