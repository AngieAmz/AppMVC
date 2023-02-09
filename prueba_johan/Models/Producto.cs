using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_johan.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}