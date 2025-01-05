using ApiTareas.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IArchivoRepository
    {
        Task<bool> subir(Archivo archivo);
    }
}
