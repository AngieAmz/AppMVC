using prueba_johan.Logica;
using prueba_johan.Models;
using System;

using System.Data;
using System.Data.SqlClient;
using System.IO;

using System.Web;
using System.Web.Mvc;

namespace prueba_johan.Controllers
{
    public class AdministradorController : Controller
    {
        Conexion bd = new Conexion();
        // GET: Administrador
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase upload, int Precio, string Descripcion)
        {
            Producto prod = new Producto();
            LO_Productos producto = new LO_Productos();
            try
            {
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    prod.Imagen = reader.ReadBytes(upload.ContentLength);
                }
                prod.Precio = Precio;
                prod.Descripcion = Descripcion;


                producto.AgregarProducto(prod);

                return RedirectToAction("Admin", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ViewBag.Message= "Error al guardar";
                return View();
            }

        }

        public ActionResult convertirImagen(int codigo)
        {
            
            string query = "select Imagen from Productos where id= "+ codigo +"";
            SqlCommand cmd = new SqlCommand(query, bd.conexion);
            bd.Open();
            byte[] image = (byte[])cmd.ExecuteScalar();

            bd.Close();

            return File(image, "Imagenes/jpg");

        }

        public ActionResult Edit(int id)
        {
            Producto registro = new Producto();
            SqlCommand cmd = new SqlCommand("select * from Productos where id= @Id", bd.conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            bd.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            registro.id = (int)dt.Rows[0][0];
            registro.Descripcion = dt.Rows[0][1].ToString();
            registro.Precio = (int)dt.Rows[0][2];
            registro.Imagen = (byte[])dt.Rows[0][3];
                
                return View(registro);
 
        }
        [HttpPost]
        public ActionResult Edit(string imagen, string Descripcion, int Precio, int id, HttpPostedFileBase upload)
        {
            Producto prod = new Producto();
            LO_Productos modificacion = new LO_Productos();
            try
            {
                if (upload == null)
                {
                    prod.Imagen = Convert.FromBase64String(imagen);
                }
                else
                {
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        prod.Imagen = reader.ReadBytes(upload.ContentLength);
                    }
                }
                
                prod.Descripcion = Descripcion;
                prod.Precio = Precio;
                prod.id = id;

                modificacion.EditarProducto(prod);

                return RedirectToAction("Admin", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ViewBag.Message = "Error al guardar";
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            Producto registro = new Producto();
            SqlCommand cmd = new SqlCommand("select * from Productos where id= @Id", bd.conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            bd.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            registro.id = (int)dt.Rows[0][0];
            registro.Descripcion = dt.Rows[0][1].ToString();
            registro.Precio = (int)dt.Rows[0][2];
            registro.Imagen = (byte[])dt.Rows[0][3];

            return View(registro);
        }

        [HttpPost]
        public ActionResult Delete(Producto prod)
        {
            try
            {

                LO_Productos eliminar = new LO_Productos();
                eliminar.EliminarProducto(prod);
                return RedirectToAction("Admin", "Home");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                ViewBag.Message = "Error al guardar";
                return View();
            }

        }



    }
}