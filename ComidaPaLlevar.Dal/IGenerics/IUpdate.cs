using System;
using ComidaPallevar.Domain.Base;
namespace ComidaPaLlevar.Dal.IGenerics
{
	/// <summary>
	/// Autor: Novatek generator
	/// Comentarios: Interface for support Update operation
	/// </summary>
	public interface IUpdate<TEntity> where TEntity : BaseObjectDomain
	{
		TEntity Update(TEntity entity);
	}
}
