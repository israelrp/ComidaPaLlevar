using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Business;

namespace ComidaPaLlevar.Controllers
{
    public class ComplementosController : Controller
    {
        //
        // GET: /Complementos/
        public ActionResult Index(int MenuId)
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            ComidaPaLlevar.Models.ListaOrden listaOrden = new Models.ListaOrden();
            listaOrden.Menu = new BOMenu().SelectByKey(MenuId);
            ViewBag.Productos = new BOProducto().RecuperarProductos();
            return View(listaOrden);
        }

        [HttpPost]
        public RedirectToRouteResult Index(ComidaPaLlevar.Models.ListaOrden listaOrden)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Index","Orden", listaOrden);
        }
	}
}