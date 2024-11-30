using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioAD { get; set; }
        public int IdRol { get; set; }

        //Only get the Rol object 
        public Rol RolUsuario { 
            get; 
                        
         }

        public Usuario()
        {
            RolUsuario = new Rol();
            
        }

        

    }
}
