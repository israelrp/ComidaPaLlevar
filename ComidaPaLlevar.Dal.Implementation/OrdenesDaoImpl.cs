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
	public class OrdenesDaoImpl : Abstracts.BaseDaoImpl, OrdenesDao
	{
		public List<Ordenes> SelectAll()
		{
			object[] parameters = new object[] { null, null };
			return Context.Database.SqlQuery<Ordenes>("dbo.usp_OrdenesSelect @UsuarioId={0}, @MenuId={1}", parameters).ToList();
		}

		public Ordenes SelectByKey(Ordenes entity)
		{
			object[] parameters = new object[] { entity.UsuarioId, entity.MenuId };
			return Context.Database.SqlQuery<Ordenes>("dbo.usp_OrdenesSelect @UsuarioId={0}, @MenuId={1}", parameters).FirstOrDefault();
		}

		public Ordenes Update(Ordenes entity)
		{
			object[] parameters = new object[] { entity.UsuarioId, entity.MenuId, entity.FechaSolicitud, entity.Comentarios, entity.Latitud, entity.Longitud, entity.Direccion, entity.Estatus };
			return Context.Database.SqlQuery<Ordenes>("dbo.usp_OrdenesUpdate @UsuarioId={0}, @MenuId={1}, @FechaSolicitud={2}, @Comentarios={3}, @Latitud={4}, @Longitud={5}, @Direccion={6}, @Estatus={7}", parameters).FirstOrDefault();
		}

		public Ordenes Insert(Ordenes entity)
		{
			object[] parameters = new object[] { entity.UsuarioId, entity.MenuId, entity.FechaSolicitud, entity.Comentarios, entity.Latitud, entity.Longitud, entity.Direccion, entity.Estatus };
			return Context.Database.SqlQuery<Ordenes>("dbo.usp_OrdenesInsert @UsuarioId={0}, @MenuId={1}, @FechaSolicitud={2}, @Comentarios={3}, @Latitud={4}, @Longitud={5}, @Direccion={6}, @Estatus={7}", parameters).FirstOrDefault();
		}

		public bool Delete(Ordenes entity)
		{
			object[] parameters = new object[] { entity.UsuarioId, entity.MenuId };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_OrdenesDelete @UsuarioId={0}, @MenuId={1}", parameters) == -1 ? true : false);
		}

	}
}
