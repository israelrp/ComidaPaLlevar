using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Dal;
using ComidaPaLlevar.Connection;
namespace ComidaPaLlevar.Dal.Implementation
{
	public class UsuarioDaoImpl : Abstracts.BaseDaoImpl, UsuarioDao
	{
		public List<Usuario> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Usuario>("dbo.usp_UsuariosSelect @Id={0}", parameters).ToList();
		}

		public Usuario SelectByKey(Usuario entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Usuario>("dbo.usp_UsuariosSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Usuario Update(Usuario entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Nombre, entity.Email, entity.Telefono, entity.Password };
			return Context.Database.SqlQuery<Usuario>("dbo.usp_UsuariosUpdate @Id={0}, @Nombre={1}, @Email={2}, @Telefono={3}, @Password={4}", parameters).FirstOrDefault();
		}

		public Usuario Insert(Usuario entity)
		{
			object[] parameters = new object[] { entity.Nombre, entity.Email, entity.Telefono, entity.Password };
			return Context.Database.SqlQuery<Usuario>("dbo.usp_UsuariosInsert @Nombre={0}, @Email={1}, @Telefono={2}, @Password={3}", parameters).FirstOrDefault();
		}

		public bool Delete(Usuario entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_UsuariosDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
