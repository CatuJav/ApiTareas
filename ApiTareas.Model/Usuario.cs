﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Model
{
    public class UsuarioMS
    {
        public int Id { get; set; }
        public string UsuarioAD { get; set; }
        public int IdRol { get; set; }
            

    }

    public class UsuarioME
    {
        public int Id { get; set; }
        public string UsuarioAD { get; set; }
        public int IdRol { get; set; }
        public int IdDepartamento { get; set; }


    }
}
