using System;
using ComidaPaLlevar.Dal.IGenerics;
using ComidaPallevar.Domain;

namespace ComidaPaLlevar.Dal
{
	/// <summary>
	/// Autor: Novatek
	/// Comentarios: Interfaces capa de datos
	/// </summary>
	public interface UsuariosDao : ISelect<Usuarios>, IUpdate<Usuarios>, IInsert<Usuarios>, IDelete<Usuarios>
	{
	}
}
