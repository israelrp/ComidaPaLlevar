using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComidaPaLlevar.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ComidaPaLlevar.Connection
{
	/// <summary>
	/// Autor: Novatek
	/// Comentarios: Clases de datos
	/// </summary>
	public class DataContext : DbContext
	{
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Orden> Ordenes { get; set; }
	}
}
