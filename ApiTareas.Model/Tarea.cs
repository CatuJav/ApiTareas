using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Model
{
    public class TareaMS
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdEstado { get; set; }
    }

    public class TareaME
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        //Hora de tipo time
        public DateTime Hora { get; set; }
        public int IdEstado { get; set; }
        public int[] IdUsuarios { get; set; }
    }
}
