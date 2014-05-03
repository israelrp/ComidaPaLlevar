using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Business;
using DevExpress.Web.Mvc;

namespace ComidaPaLlevar.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            Usuarios usuario = (Usuarios)Session["UsuarioLogueado"];
            BOOrden boOrden = new BOOrden();
            Ordenes orden = boOrden.BuscarOrdenDelDia(usuario.Id);
            if (orden != null)
            {
                return Redirect("~/Orden/Estatus");
            }
            List<Menus> menus = new BOMenu().RecuperarMenuDia();
            return View(menus);
        }

        [HttpPost]
        public RedirectResult Index(int MenuId)
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            return Redirect("~/Orden/Index?MenuId="+MenuId.ToString());
        }



        [ValidateInput(false)]
        public ActionResult GridViewPartialMenus()
        {
            var model = new BOMenu().RecuperarMenus();
            return PartialView("_GridViewPartialMenus", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMenusAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPallevar.Domain.Menus item)
        {
            BOMenu boMenu = new BOMenu();
            List<Menus> model = new List<Menus>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    item = boMenu.InsertarMenu(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            model = boMenu.RecuperarMenus();
            return PartialView("_GridViewPartialMenus", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMenusUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPallevar.Domain.Menus item)
        {
            BOMenu boMenu = new BOMenu();
            List<Menus> model = new List<Menus>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    item=boMenu.ActualizarMenu(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            model = boMenu.RecuperarMenus();
            return PartialView("_GridViewPartialMenus", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMenusDelete(System.Int32 Id)
        {
            BOMenu boMenu = new BOMenu();
            List<Menus> model = new List<Menus>();
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    boMenu.EliminarMenu(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            model = boMenu.RecuperarMenus();
            return PartialView("_GridViewPartialMenus", model);
        }
	}
}