using System;
using ComidaPaLlevar.Domain.Base;
namespace ComidaPaLlevar.Dal.IGenerics
{
	/// <summary>
	/// Autor: Novatek generator
	/// Comentarios: Interface for support Insert operation
	/// </summary>
	public interface IInsert<TEntity> where TEntity : BaseObjectDomain
	{
		TEntity Insert(TEntity entity);
	}
}
