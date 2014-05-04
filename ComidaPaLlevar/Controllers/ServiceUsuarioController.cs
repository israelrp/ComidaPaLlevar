using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Business;

namespace ComidaPaLlevar.Controllers
{
    public class ServiceUsuarioController : ApiController
    {
        [HttpPost]
        public Usuario NuevoUsuario(Usuario usuario)
        {
            return new BOUsuario().NuevoUsuario(usuario);
        }

        [HttpGet]
        public int Autenticar(string email, string password)
        {
            int id=0;
            Usuario usuario=new BOUsuario().Autenticar(email, password);
            if(usuario!=null){
                id=usuario.Id;
            }
            return id;
        }

        [HttpPost]
        public bool EliminarUsuario(Usuario usuario)
        {
            BOUsuario boUsuario = new BOUsuario();
            return boUsuario.EliminarUsuario(usuario);
        }
    }
}
