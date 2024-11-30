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
        Task<IEnumerable<Usuario>> obtenerUsuarios();
        Task<Usuario> obtenerUsuariosPorId(int id);
        Task<bool> crearUsuario(Usuario usuario);
        Task<bool> actualizarUsuario(Usuario usuario);
        Task<bool> eliminarUsuario(Usuario usuario);
    }
}
