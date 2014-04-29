using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Business;
using ComidaPallevar.Domain;
using DevExpress.Web.Mvc;

namespace ComidaPaLlevar.Controllers
{
    public class OrdenController : Controller
    {
        //
        // GET: /Orden/
        public ActionResult Index(int MenuId)
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            Ordenes orden = new Ordenes();
            orden.Menu = new BOMenu().SelectByKey(MenuId);
            return View(orden);
        }

        [HttpPost]
        public RedirectToRouteResult Index(Ordenes orden)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index","Home");
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

        public ActionResult Estatus()
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Home");
            Usuarios usuario = (Usuarios)Session["UsuarioLogueado"];
            Ordenes orden = new BOOrden().BuscarOrdenDelDia(usuario.Id);
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
        public ActionResult GridViewPartialOrdenesAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPallevar.Domain.Ordenes item)
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
        public ActionResult GridViewPartialOrdenesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPallevar.Domain.Ordenes item)
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