using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Models;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Business;
using DevExpress.Web.Mvc;

namespace ComidaPaLlevar.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        public PartialViewResult PartialRegistroUsuario()
        {
            return PartialView();
        }

        [HttpPost]
        public RedirectResult PartialRegistroUsuario(RegistroUsuarioModel registro)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = registro.Nombre;
            usuario.Email = registro.Email;
            usuario.Password = registro.PasswordConfirmacion;
            usuario.Telefono = registro.Telefono;
            usuario = new BOUsuario().NuevoUsuario(usuario);
            if (usuario != null)
            {
                return Redirect("~/Home/Index?Registro=true");
            }
            else
            {
                return Redirect("~/Home/Index?Registro=false");
            }
        }

        public PartialViewResult PartialLoginUsuario()
        {
            return PartialView();
        }

        public RedirectResult LogOut()
        {
            Session["UsuarioLogueado"] = null;
            return Redirect("~/Home/");
        }

        [HttpPost]
        public RedirectResult PartialLoginUsuario(LoginModel login)
        {
            BOUsuario boUsuario = new BOUsuario();
            Usuario usuario = boUsuario.Autenticar(login.Email, login.Password);
            if (usuario != null)
            {
                Session["UsuarioLogueado"] = usuario;
                return Redirect("~/Menu");
            }
            else
            {
                Session["UsuarioLogueado"] = null;
                return Redirect("~/Home/Index?Login=false");
            }
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartialClientes()
        {
            var model = new BOUsuario().RecuperarUsuario();
            return PartialView("_GridViewPartialClientes", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialClientesAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Usuario item)
        {
            BOUsuario boUsuario = new BOUsuario();
            List<Usuario> model = new List<Usuario>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    item = boUsuario.NuevoUsuario(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            model = boUsuario.RecuperarUsuario();
            return PartialView("_GridViewPartialClientes", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialClientesUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ComidaPaLlevar.Domain.Usuario item)
        {
            BOUsuario boUsuario = new BOUsuario();
            List<Usuario> model = new List<Usuario>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    item = boUsuario.ActualizarUsuario(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            model = boUsuario.RecuperarUsuario();
            return PartialView("_GridViewPartialClientes", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialClientesDelete(System.Int32 Id)
        {
            BOUsuario boUsuario = new BOUsuario();
            List<Usuario> model = new List<Usuario>();
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    boUsuario.EliminarUsuario(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            model = boUsuario.RecuperarUsuario();
            return PartialView("_GridViewPartialClientes", model);
        }

        public JsonResult RecuperarPassword(string Email)
        {
            bool resultado = false;
            Usuario usuario = new BOUsuario().RecuperarUsuarioByEmail(Email);
            if (usuario != null)
            {
                ComidaPaLlevar.Business.Tools.EmailSender sender= new Business.Tools.EmailSender();
                sender.SendMail("Hola " + usuario.Nombre + ", <br/><br/> Tu contraseña es: " + usuario.Password + ". <br/><br/> www.comoenksa.com", usuario.Email, "noreply@comoenksa.com", "Recuperación contraseña ComoEnKsa");
                resultado = true;
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
	}
}