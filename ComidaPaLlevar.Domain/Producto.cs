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
	[Table("Productos")]
	public class Producto : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		[StringLength(80)]
		public string Nombre { get; set; } //(varchar(1), not null)
		[Required]
		[StringLength(300)]
		public string Descripción { get; set; } //(varchar(1), not null)
		public string FotoUrl { get; set; } //(nvarchar(1), null)
		[Required]
		[DataType(DataType.Currency)]
		public decimal Precio { get; set; } //(money, not null)
		[Required]
		public bool Disponible { get; set; } //(bit, not null)
	}
}
