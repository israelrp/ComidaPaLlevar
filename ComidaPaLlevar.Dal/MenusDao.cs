using System;
using ComidaPaLlevar.Dal.IGenerics;
using ComidaPallevar.Domain;

namespace ComidaPaLlevar.Dal
{
	/// <summary>
	/// Autor: Novatek
	/// Comentarios: Interfaces capa de datos
	/// </summary>
	public interface MenusDao : ISelect<Menus>, IUpdate<Menus>, IInsert<Menus>, IDelete<Menus>
	{
	}
}
