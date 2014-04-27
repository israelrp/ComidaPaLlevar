using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComidaPallevar.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ComidaPaLlevar.Connection
{
	/// <summary>
	/// Autor: Novatek
	/// Comentarios: Clases de datos
	/// </summary>
	public class DataContext : DbContext
	{
		public DbSet<Menus> Menus { get; set; }
		public DbSet<Usuarios> Usuarios { get; set; }
		public DbSet<Ordenes> Ordenes { get; set; }
	}
}
