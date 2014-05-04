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
	public class SalidaDaoImpl : Abstracts.BaseDaoImpl, SalidaDao
	{
		public List<Salida> SelectAll()
		{
			object[] parameters = new object[] { null };
			return Context.Database.SqlQuery<Salida>("dbo.usp_SalidasSelect @Id={0}", parameters).ToList();
		}

		public Salida SelectByKey(Salida entity)
		{
			object[] parameters = new object[] { entity.Id };
			return Context.Database.SqlQuery<Salida>("dbo.usp_SalidasSelect @Id={0}", parameters).FirstOrDefault();
		}

		public Salida Update(Salida entity)
		{
			object[] parameters = new object[] { entity.Id, entity.Productoid, entity.OrdenId, entity.Precio, entity.FechaSolicitud, entity.Cantidad };
			return Context.Database.SqlQuery<Salida>("dbo.usp_SalidasUpdate @Id={0}, @Productoid={1}, @OrdenId={2}, @Precio={3}, @FechaSolicitud={4}, @Cantidad={5}", parameters).FirstOrDefault();
		}

		public Salida Insert(Salida entity)
		{
			object[] parameters = new object[] { entity.Productoid, entity.OrdenId, entity.Precio, entity.FechaSolicitud, entity.Cantidad };
			return Context.Database.SqlQuery<Salida>("dbo.usp_SalidasInsert @Productoid={0}, @OrdenId={1}, @Precio={2}, @FechaSolicitud={3}, @Cantidad={4}", parameters).FirstOrDefault();
		}

		public bool Delete(Salida entity)
		{
			object[] parameters = new object[] { entity.Id };
			return (Context.Database.ExecuteSqlCommand("dbo.usp_SalidasDelete @Id={0}", parameters) == -1 ? true : false);
		}

	}
}
