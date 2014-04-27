using System;
using System.Collections.Generic;
using ComidaPallevar.Domain.Base;
namespace ComidaPaLlevar.Dal.IGenerics
{
	/// <summary>
	/// Autor: Novatek generator
	/// Comentarios: Interface for support Update operation
	/// </summary>
	public interface ISelect<TEntity> where TEntity : BaseObjectDomain
	{
		List<TEntity> SelectAll();
		TEntity SelectByKey(TEntity entity);
	}
}
