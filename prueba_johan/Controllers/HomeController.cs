
using System.Web.Mvc;
using System.Web.Security;
using prueba_johan.Models;
using prueba_johan.Logica;
using prueba_johan.Permisos;

namespace prueba_johan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Conexion bd = new Conexion();
        LO_Productos dt = new LO_Productos();

        public ActionResult Index()
        {

            return View(dt.MostrarProducto());
        }


        [PermisosRol(Rol.Admin)]
        public ActionResult Admin()
        {
            return View(dt.MostrarProducto());

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bienvenido a la pagina de contacto.";

            return View();
        }

        public ActionResult NotAllowed()
        {
            ViewBag.Message = "No tiene permitido acceder a esta pagina.";

            return View();
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;

            return RedirectToAction("Login", "Acceso");
        }
    }
}