using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> obtenerDepartamentos();
        Task<Departamento> obtenerDepartamentoPorId(int id);
        Task<bool> crearDepartamento(Departamento estado);
        Task<bool> actualizarDepartamento(Departamento estado);
        Task<bool> eliminarDepartamento(Departamento estado);
    }
}
