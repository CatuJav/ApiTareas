﻿using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> obtenerTareas();
        Task<Tarea> obtenerTareaPorId(int id);
        Task<bool> crearTarea(Tarea tarea);
        Task<bool> actualizarTarea(Tarea tarea);
        Task<bool> eliminarTarea(Tarea tarea);
    }

}