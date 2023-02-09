using prueba_johan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace prueba_johan.Logica
{
    public class LO_Productos
    {
        SqlCommand cmd;
        Conexion bd = new Conexion();

        public DataTable MostrarProducto()
        {

                string query = "select id, Descripcion, Precio from Productos";
                SqlDataAdapter sda = new SqlDataAdapter(query, bd.conexion);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                return dt;

        }

        public void AgregarProducto(Producto prod)
        {

            using (bd.conexion)
            {
                string query = "insert into Productos (Descripcion, Precio, Imagen) values (@desc, @precio, @img)";
                cmd = new SqlCommand(query, bd.conexion);
                cmd.Parameters.AddWithValue("@desc", prod.Descripcion);
                cmd.Parameters.AddWithValue("@precio", prod.Precio);
                cmd.Parameters.AddWithValue("@img", prod.Imagen);
                cmd.CommandType = CommandType.Text;

                bd.Open();
                cmd.ExecuteNonQuery();
                bd.Close();

            }
        }

        public void EditarProducto(Producto prod)
        {
            using (bd.conexion)
            {
                string query = "update Productos set Descripcion = @desc, Precio = @precio, Imagen = @imagen where id = @id";
                cmd = new SqlCommand(query, bd.conexion);
                cmd.Parameters.AddWithValue("@id", prod.id);
                cmd.Parameters.AddWithValue("@desc", prod.Descripcion);
                cmd.Parameters.AddWithValue("@precio", prod.Precio);
                cmd.Parameters.AddWithValue("@imagen", prod.Imagen);
                cmd.CommandType = CommandType.Text;

                bd.Open();
                cmd.ExecuteNonQuery();
                bd.Close();

            }
        }

        public void EliminarProducto(Producto prod)
        {
            string query = "delete from Productos where id = @id";
            cmd = new SqlCommand(query, bd.conexion);
            cmd.Parameters.AddWithValue("@id", prod.id);
            bd.Open();
            cmd.ExecuteNonQuery();
            bd.Close();
        }


    }
}