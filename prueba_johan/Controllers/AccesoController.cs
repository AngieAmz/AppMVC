
using System.Web.Mvc;
using prueba_johan.Models;
using prueba_johan.Logica;
using System.Web.Security;

namespace prueba_johan.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Correo, string Clave)
        {
            Usuarios objeto = new LO_Usuario().EncontrarUsuario(Correo, Clave);

            if(objeto.Nombre != null)
            {

                FormsAuthentication.SetAuthCookie(objeto.Correo, false);

                Session["Usuario"] = objeto;

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(string Nombre, string Correo, string Clave1, string Clave2)
        {
            if(Clave1 != Clave2)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
            }
            else
            {
                Usuarios objeto = new Usuarios();
                LO_Usuario user = new LO_Usuario();
                objeto.Nombre = Nombre;
                objeto.Correo = Correo;
                objeto.Clave = Clave1;

                user.AgregarUsuario(objeto);

                ViewBag.Message = "Registro exitoso!";

            }
            return View();
        }

    }
}