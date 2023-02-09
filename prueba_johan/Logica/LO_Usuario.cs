using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_johan.Models;
using System.Data.SqlClient;
using System.Data;

namespace prueba_johan.Logica
{
    public class LO_Usuario
    {
        Usuarios objeto = new Usuarios();
        Conexion bd = new Conexion();
        public Usuarios EncontrarUsuario(string Correo, string Clave)
        {
            
            using(bd.conexion)
            {
                string query = "select Nombre,Correo,Clave,IdRol from USUARIOS where Correo = @pcorreo and Clave = @pclave";
                SqlCommand cmd = new SqlCommand(query, bd.conexion);
                cmd.Parameters.AddWithValue("@pcorreo", Correo);
                cmd.Parameters.AddWithValue("@pclave", Clave);
                cmd.CommandType = CommandType.Text;

                bd.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new Usuarios()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IdRol = (Rol)dr["IdRol"],
                        };
                    }
                }
                bd.Close();
            }

            return objeto;
        }

        public void AgregarUsuario(Usuarios user)
        {

            using (bd.conexion)
            {
                string query = "insert into USUARIOS (Nombre, Correo, Clave, IdRol) values (@nombre, @correo, @clave, @idrol)";
                SqlCommand cmd = new SqlCommand(query, bd.conexion);
                cmd.Parameters.AddWithValue("@nombre", user.Nombre);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@clave", user.Clave);
                cmd.Parameters.AddWithValue("idrol", 2);
                cmd.CommandType = CommandType.Text;

                bd.Open();
                cmd.ExecuteNonQuery();
                bd.Close();
            }

        }


    }
}