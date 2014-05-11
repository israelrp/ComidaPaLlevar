using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Business;
using DevExpress.Web.Mvc;

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

        [ValidateInput(false)]
        public ActionResult GridViewPartialOrdenComplementos()
        {
            List<Salida> model = new List<Salida>();
            BOSalida boSalida = new BOSalida();
            model = boSalida.RecuperarSalidas();
            foreach (var salida in model)
            {
                salida.Producto = new BOProducto().SelectByKey(salida.Productoid);
                salida.Usuario = new BOUsuario().SelectByKey(new BOOrden().SelectById(salida.OrdenId).UsuarioId);
            }
            return PartialView("_GridViewPartialOrdenComplementos", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenComplementosAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Salida item)
        {
            List<Salida> model = new List<Salida>();
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
            return PartialView("_GridViewPartialOrdenComplementos", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenComplementosUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Salida item)
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
            return PartialView("_GridViewPartialOrdenComplementos", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOrdenComplementosDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
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
            return PartialView("_GridViewPartialOrdenComplementos", model);
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartialProductos()
        {
            var model = new BOProducto().RecuperarProductos();
            return PartialView("_GridViewPartialProductos", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialProductosAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Producto item)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    BOProducto boProducto = new BOProducto();
                    boProducto.NuevoProducto(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = new BOProducto().RecuperarProductos();
            return PartialView("_GridViewPartialProductos", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialProductosUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Producto item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    BOProducto boProducto = new BOProducto();
                    boProducto.ActualizarProducto(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = new BOProducto().RecuperarProductos();
            return PartialView("_GridViewPartialProductos", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialProductosDelete(System.Int32 Id)
        {
            
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    BOProducto boProducto = new BOProducto();
                    boProducto.EliminarProducto(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = new BOProducto().RecuperarProductos();
            return PartialView("_GridViewPartialProductos", model);
        }
	}
}