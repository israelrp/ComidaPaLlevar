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
	public class OrdenDaoImpl : Abstracts.BaseDaoImpl, OrdenDao
	{
		public List<Orden> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Orden>("dbo.usp_OrdenesSelect @Id={0}", parameters).ToList();
		}

		public Orden SelectByKey(Orden entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Orden>("dbo.usp_OrdenesSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Orden Update(Orden entity)
		{
			object[] parameters = new object[] { entity.Id, entity.UsuarioId, entity.MenuId, entity.FechaSolicitud, entity.Comentarios, entity.Latitud, entity.Longitud, entity.Direccion, entity.Estatus };
			return Context.Database.SqlQuery<Orden>("dbo.usp_OrdenesUpdate @Id={0}, @UsuarioId={1}, @MenuId={2}, @FechaSolicitud={3}, @Comentarios={4}, @Latitud={5}, @Longitud={6}, @Direccion={7}, @Estatus={8}", parameters).FirstOrDefault();
		}

		public Orden Insert(Orden entity)
		{
			object[] parameters = new object[] { entity.UsuarioId, entity.MenuId, entity.FechaSolicitud, entity.Comentarios, entity.Latitud, entity.Longitud, entity.Direccion, entity.Estatus };
			return Context.Database.SqlQuery<Orden>("dbo.usp_OrdenesInsert @UsuarioId={0}, @MenuId={1}, @FechaSolicitud={2}, @Comentarios={3}, @Latitud={4}, @Longitud={5}, @Direccion={6}, @Estatus={7}", parameters).FirstOrDefault();
		}

		public bool Delete(Orden entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_OrdenesDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
