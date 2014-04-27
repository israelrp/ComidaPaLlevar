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
	public class MenusDaoImpl : Abstracts.BaseDaoImpl, MenusDao
	{
		public List<Menus> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Menus>("dbo.usp_MenusSelect @Id={0}", parameters).ToList();
		}

		public Menus SelectByKey(Menus entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Menus>("dbo.usp_MenusSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Menus Update(Menus entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Nombre, entity.Descripcion, entity.Precio, entity.Imagen, entity.FechaVigencia };
			return Context.Database.SqlQuery<Menus>("dbo.usp_MenusUpdate @Id={0}, @Nombre={1}, @Descripcion={2}, @Precio={3}, @Imagen={4}, @FechaVigencia={5}", parameters).FirstOrDefault();
		}

		public Menus Insert(Menus entity)
		{
			object[] parameters = new object[] { entity.Nombre, entity.Descripcion, entity.Precio, entity.Imagen, entity.FechaVigencia };
			return Context.Database.SqlQuery<Menus>("dbo.usp_MenusInsert @Nombre={0}, @Descripcion={1}, @Precio={2}, @Imagen={3}, @FechaVigencia={4}", parameters).FirstOrDefault();
		}

		public bool Delete(Menus entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_MenusDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
