using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface ILoginRepository
    {
        Task<LoginResp> login(Credenciales credenciales);
    }
}
