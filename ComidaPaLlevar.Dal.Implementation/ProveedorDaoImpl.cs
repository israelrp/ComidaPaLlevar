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
	public class ProveedorDaoImpl : Abstracts.BaseDaoImpl, ProveedorDao
	{
		public List<Proveedor> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Proveedor>("dbo.usp_ProveedoresSelect @Id={0}", parameters).ToList();
		}

		public Proveedor SelectByKey(Proveedor entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Proveedor>("dbo.usp_ProveedoresSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Proveedor Update(Proveedor entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Nombre, entity.Email };
			return Context.Database.SqlQuery<Proveedor>("dbo.usp_ProveedoresUpdate @Id={0}, @Nombre={1}, @Email={2}", parameters).FirstOrDefault();
		}

		public Proveedor Insert(Proveedor entity)
		{
			object[] parameters = new object[] { entity.Nombre, entity.Email };
			return Context.Database.SqlQuery<Proveedor>("dbo.usp_ProveedoresInsert @Nombre={0}, @Email={1}", parameters).FirstOrDefault();
		}

		public bool Delete(Proveedor entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_ProveedoresDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
