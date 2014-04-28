using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Business;
using ComidaPallevar.Domain;

namespace ComidaPaLlevar.Controllers
{
    public class OrdenController : Controller
    {
        //
        // GET: /Orden/
        public ActionResult Index(int MenuId)
        {
            Ordenes orden = new Ordenes();
            orden.Menu = new BOMenu().SelectByKey(MenuId);
            return View(orden);
        }

        [HttpPost]
        public ActionResult Index(Ordenes orden)
        {
            
            return View(orden);
        }
	}
}