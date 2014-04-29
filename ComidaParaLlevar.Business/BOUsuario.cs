using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Dal.Implementation;
using ComidaPallevar.Domain;

namespace ComidaPaLlevar.Business
{
    public class BOUsuario
    {
        public Usuarios NuevoUsuario(Usuarios usuario)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.Insert(usuario);
        }

        public Usuarios ActualizarUsuario(Usuarios usuario)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.Update(usuario);
        }

        public bool EliminarUsuario(Usuarios usuario)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.Delete(usuario);
        }

        public bool EliminarUsuario(int Id)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.Delete(new Usuarios { Id=Id });
        }

        public Usuarios SelectByKey(int UsuarioId)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.SelectByKey(new Usuarios { Id = UsuarioId });
        }

        public List<Usuarios> RecuperarUsuarios()
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            return usuariosDaoImpl.SelectAll();
        }

        public Usuarios Autenticar(string email, string password)
        {
            UsuariosDaoImpl usuariosDaoImpl = new UsuariosDaoImpl();
            Usuarios usuario = usuariosDaoImpl.SelectAll().Where(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower()==password.ToLower()).FirstOrDefault();
            return usuario;
        }
    }
}
