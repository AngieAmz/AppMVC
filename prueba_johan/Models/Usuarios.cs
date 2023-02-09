using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_johan.Models
{
    public class Usuarios
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public Rol IdRol { get; set; }
    }
}