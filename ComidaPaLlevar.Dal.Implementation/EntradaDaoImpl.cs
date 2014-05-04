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
	public class EntradaDaoImpl : Abstracts.BaseDaoImpl, EntradaDao
	{
		public List<Entrada> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Entrada>("dbo.usp_EntradasSelect @Id={0}", parameters).ToList();
		}

		public Entrada SelectByKey(Entrada entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Entrada>("dbo.usp_EntradasSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Entrada Update(Entrada entity)
		{
			object[] parameters = new object[] { entity.Id, entity.ProductoId, entity.ProveedorId, entity.FechaEntrada, entity.Cantidad, entity.Costo };
			return Context.Database.SqlQuery<Entrada>("dbo.usp_EntradasUpdate @Id={0}, @ProductoId={1}, @ProveedorId={2}, @FechaEntrada={3}, @Cantidad={4}, @Costo={5}", parameters).FirstOrDefault();
		}

		public Entrada Insert(Entrada entity)
		{
			object[] parameters = new object[] { entity.ProductoId, entity.ProveedorId, entity.FechaEntrada, entity.Cantidad, entity.Costo };
			return Context.Database.SqlQuery<Entrada>("dbo.usp_EntradasInsert @ProductoId={0}, @ProveedorId={1}, @FechaEntrada={2}, @Cantidad={3}, @Costo={4}", parameters).FirstOrDefault();
		}

		public bool Delete(Entrada entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_EntradasDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
