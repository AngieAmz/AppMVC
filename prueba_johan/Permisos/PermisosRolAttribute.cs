using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba_johan.Models;

namespace prueba_johan.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {

        private Rol idRol;

        public PermisosRolAttribute(Rol _idRol)
        {
            idRol = _idRol;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["Usuario"] != null)
            {
                Usuarios user = HttpContext.Current.Session["Usuario"] as Usuarios;

                if (user.IdRol != this.idRol)
                {
                    filterContext.Result = new RedirectResult("~/Home/NotAllowed");
                }
            }


            base.OnActionExecuting(filterContext);
        }


    }
}