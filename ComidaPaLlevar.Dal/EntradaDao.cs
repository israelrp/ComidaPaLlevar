using System;
using ComidaPaLlevar.Dal.IGenerics;
using ComidaPaLlevar.Domain;
namespace ComidaPaLlevar.Dal
{
	/// <summary>
	/// Autor: Israel Romero Ponce
	/// Comentarios: Interfaces para el CRUD
	/// </summary>
	public interface EntradaDao : ISelect<Entrada>, IUpdate<Entrada>, IInsert<Entrada>, IDelete<Entrada>
	{
	}
}
