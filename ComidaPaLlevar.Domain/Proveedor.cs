using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComidaPaLlevar.Domain
{
	/// <summary>
	/// Autor: Israel Romero Ponce
	/// Comentarios: Clases de objetos de datos
	/// </summary>
	[Table("Proveedores")]
	public class Proveedor : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; } //(varchar(1), not null)
		[Required]
		[StringLength(150)]
		public string Email { get; set; } //(varchar(1), not null)
	}
}
