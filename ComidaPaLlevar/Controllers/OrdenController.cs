using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Business;
using ComidaPaLlevar.Domain;
using DevExpress.Web.Mvc;

namespace ComidaPaLlevar.Controllers
{
    public class OrdenController : Controller
    {
        //
        // GET: /Orden/
        public ActionResult Index(ComidaPaLlevar.Models.ListaOrden listaOrden)
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            listaOrden.Menu = new BOMenu().SelectByKey(listaOrden.MenuId);
            foreach (var item in listaOrden.CantidadesProducto)
            {
                if (item.Cantidad > 0)
                {
                    item.Producto = new BOProducto().SelectByKey(item.ProductoId);
                }
            }
            return View(listaOrden);
        }

        [ActionName("Index")]
        [HttpPost]
        public RedirectToRouteResult Confirmar(ComidaPaLlevar.Models.ListaOrden listaOrden)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index","Home");
            BOOrden boOrden = new BOOrden();
            Orden orden = new Orden();
            orden.FechaSolicitud = DateTime.Now;
            Usuario usuario=(Usuario)Session["UsuarioLogueado"];
            orden.UsuarioId = usuario.Id;
            orden.MenuId = listaOrden.MenuId;
            orden=boOrden.NuevaOrden(orden);
            return RedirectToAction("Confirmado",orden);
        }

        public ActionResult Confirmado(Orden orden) 
        {
            int numeroOrden = orden.UsuarioId + orden.MenuId + orden.FechaSolicitud.Day + orden.FechaSolicitud.Second;
            Usuario usuario = new BOUsuario().SelectByKey(orden.UsuarioId);
            ViewBag.NumeroOrden = usuario.Nombre.Substring(0,3).ToUpper()+ numeroOrden.ToString(); 
            return View();
        }

        public ActionResult Estatus()
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Home");
            Usuario usuario = (Usuario)Session["UsuarioLogueado"];
            Orden orden = new BOOrden().BuscarOrdenDelDia(usuario.Id);
            int numeroOrden = orden.UsuarioId + orden.MenuId + orden.FechaSolicitud.Day + orden.FechaSolicitud.Second;
            ViewBag.NumeroOrden = usuario.Nombre.Substring(0, 3).ToUpper() + numeroOrden.ToString(); 
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialOrdenes()
        {
            var model = new BOOrden().RecuperarOrdenes();
            return PartialView("_GridViewPartialOrdenes", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenesAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Orden item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialOrdenes", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Orden item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialOrdenes", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenesDelete(System.Int32 UsuarioId)
        {
            var model = new object[0];
            if (UsuarioId >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartialOrdenes", model);
        }

       
	}
}