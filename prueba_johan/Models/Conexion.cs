using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba_johan.Models
{
    public class Conexion
    {

        public SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-U1TV8IU\\SQLEXPRESS; Initial Catalog=PruebaJohan; Integrated Security=true");
        

        public void Open()
        {
            conexion.Open();
        }

        public void Close()
        {
            conexion.Close();
        }

    }
}