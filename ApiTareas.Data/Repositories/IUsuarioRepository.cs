using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioMS>> obtenerUsuarios();
        Task<UsuarioMS> obtenerUsuariosPorId(int id);
        Task<UsuarioMS> obtenerUnoUsuarioPorNombre(string usuario);
        Task<bool> crearUsuario(UsuarioME usuario);
        Task<bool> actualizarUsuario(UsuarioME usuario);
        Task<bool> eliminarUsuario(UsuarioME usuario);
    }
}
