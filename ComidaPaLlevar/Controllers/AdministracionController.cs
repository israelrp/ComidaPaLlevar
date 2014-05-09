using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ComidaPaLlevar.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/
        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return View();
        }

        public ActionResult Ordenes()
        {
            return View();
        }

       
	}
}