using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPaLlevar.Models;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Business;

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
            Usuarios usuario = new Usuarios();
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

        [HttpPost]
        public RedirectResult PartialLoginUsuario(LoginModel login)
        {
            BOUsuario boUsuario = new BOUsuario();
            Usuarios usuario = boUsuario.Autenticar(login.Email, login.Password);
            if (usuario != null)
            {
                return Redirect("~/Home/Menu");
            }
            else
            {
                return Redirect("~/Home/Index?Login=false");
            }
        }
	}
}