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
	public class ProductoDaoImpl : Abstracts.BaseDaoImpl, ProductoDao
	{
		public List<Producto> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Producto>("dbo.usp_ProductosSelect @Id={0}", parameters).ToList();
		}

		public Producto SelectByKey(Producto entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Producto>("dbo.usp_ProductosSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Producto Update(Producto entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Nombre, entity.Descripción, entity.FotoUrl, entity.Precio, entity.Disponible };
			return Context.Database.SqlQuery<Producto>("dbo.usp_ProductosUpdate @Id={0}, @Nombre={1}, @Descripción={2}, @FotoUrl={3}, @Precio={4}, @Disponible={5}", parameters).FirstOrDefault();
		}

		public Producto Insert(Producto entity)
		{
			object[] parameters = new object[] { entity.Nombre, entity.Descripción, entity.FotoUrl, entity.Precio, entity.Disponible };
			return Context.Database.SqlQuery<Producto>("dbo.usp_ProductosInsert @Nombre={0}, @Descripción={1}, @FotoUrl={2}, @Precio={3}, @Disponible={4}", parameters).FirstOrDefault();
		}

		public bool Delete(Producto entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_ProductosDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
