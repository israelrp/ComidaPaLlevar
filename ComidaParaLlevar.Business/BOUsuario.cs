using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Dal.Implementation;
using ComidaPaLlevar.Domain;

namespace ComidaPaLlevar.Business
{
    public class BOUsuario
    {
        public Usuario NuevoUsuario(Usuario usuario)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            Usuario usuarioExiste = UsuarioDaoImpl.SelectAll().Where(x => x.Email == usuario.Email).FirstOrDefault();
            if (usuarioExiste == null)
                return UsuarioDaoImpl.Insert(usuario);
            else
                return null;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            return UsuarioDaoImpl.Update(usuario);
        }

        public bool EliminarUsuario(Usuario usuario)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            return UsuarioDaoImpl.Delete(usuario);
        }

        public bool EliminarUsuario(int Id)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            return UsuarioDaoImpl.Delete(new Usuario { Id=Id });
        }

        public Usuario SelectByKey(int UsuarioId)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            return UsuarioDaoImpl.SelectByKey(new Usuario { Id = UsuarioId });
        }

        public List<Usuario> RecuperarUsuario()
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            return UsuarioDaoImpl.SelectAll();
        }

        public Usuario Autenticar(string email, string password)
        {
            UsuarioDaoImpl UsuarioDaoImpl = new UsuarioDaoImpl();
            Usuario usuario = UsuarioDaoImpl.SelectAll().Where(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower()==password.ToLower()).FirstOrDefault();
            return usuario;
        }
    }
}
