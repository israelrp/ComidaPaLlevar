using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Dal;
using ComidaPaLlevar.Connection;
namespace ComidaPaLlevar.Dal.Implementation
{
	public class UsuariosDaoImpl : Abstracts.BaseDaoImpl, UsuariosDao
	{
		public List<Usuarios> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Usuarios>("dbo.usp_UsuariosSelect @Id={0}", parameters).ToList();
		}

		public Usuarios SelectByKey(Usuarios entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Usuarios>("dbo.usp_UsuariosSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Usuarios Update(Usuarios entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Nombre, entity.Email, entity.Telefono, entity.Password };
			return Context.Database.SqlQuery<Usuarios>("dbo.usp_UsuariosUpdate @Id={0}, @Nombre={1}, @Email={2}, @Telefono={3}, @Password={4}", parameters).FirstOrDefault();
		}

		public Usuarios Insert(Usuarios entity)
		{
			object[] parameters = new object[] { entity.Nombre, entity.Email, entity.Telefono, entity.Password };
            return Context.Database.SqlQuery<Usuarios>("dbo.usp_UsuariosInsert @Nombre={0}, @Email={1}, @Telefono={2}, @Password={3}", parameters).FirstOrDefault();
		}

		public bool Delete(Usuarios entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_UsuariosDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
