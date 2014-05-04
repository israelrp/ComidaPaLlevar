using System;
using ComidaPaLlevar.Dal.IGenerics;
using ComidaPaLlevar.Domain;
namespace ComidaPaLlevar.Dal
{
	/// <summary>
	/// Autor: Israel Romero Ponce
	/// Comentarios: Interfaces para el CRUD
	/// </summary>
	public interface MenuDao : ISelect<Menu>, IUpdate<Menu>, IInsert<Menu>, IDelete<Menu>
	{
	}
}
