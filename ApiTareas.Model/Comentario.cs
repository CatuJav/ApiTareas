using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Model
{
    public class ComentarioME
    {
        public string comentario { get; set; }
        public int idUsuario { get; set; }
        public int idTarea { get; set; }
    }

    public class  ComentarioMS
    {
        public int id { get; set; }
        public string comentario { get; set; }
        public int idUsuario { get; set; }
        public string usuarioAD { get; set; }
        public int idTarea { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }

    }
}
