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
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            Usuario usuario = (Usuario)Session["UsuarioLogueado"];
            BOOrden boOrden = new BOOrden();
            Orden orden = boOrden.BuscarOrdenDelDia(usuario.Id);
            if (orden != null)
            {
                return Redirect("~/Orden/Estatus");
            }
            List<Menu> menus = new BOMenu().RecuperarMenuDia();            
            return View(menus);
        }

        [HttpPost]
        public RedirectResult Index(int MenuId)
        {
            if (Session["UsuarioLogueado"] == null)
                return Redirect("~/Home/Index");
            return Redirect("~/Complementos/Index?MenuId="+MenuId.ToString());
        }



        [ValidateInput(false)]
        public ActionResult GridViewPartialMenus()
        {
            var model = new BOMenu().RecuperarMenus();
            return PartialView("_GridViewPartialMenus", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMenusAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Menu item)
        {
            BOMenu boMenu = new BOMenu();
            List<Menu> model = new List<Menu>();
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
        public ActionResult GridViewPartialMenusUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Menu item)
        {
            BOMenu boMenu = new BOMenu();
            List<Menu> model = new List<Menu>();
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
            List<Menu> model = new List<Menu>();
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