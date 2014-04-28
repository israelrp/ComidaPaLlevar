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
        public RedirectToRouteResult Index(Ordenes orden)
        {
            BOOrden boOrden = new BOOrden();
            orden.FechaSolicitud = DateTime.Now;
            Usuarios usuario=(Usuarios)Session["UsuarioLogueado"];
            orden.UsuarioId = usuario.Id;
            orden=boOrden.NuevaOrden(orden);
            return RedirectToAction("Confirmado",orden);
        }

        public ActionResult Confirmado(Ordenes orden) 
        {
            int numeroOrden = orden.UsuarioId + orden.MenuId + orden.FechaSolicitud.Day + orden.FechaSolicitud.Second;
            Usuarios usuario = new BOUsuario().SelectByKey(orden.UsuarioId);
            ViewBag.NumeroOrden = usuario.Nombre.Substring(0,3).ToUpper()+ numeroOrden.ToString(); 
            return View();
        }
	}
}