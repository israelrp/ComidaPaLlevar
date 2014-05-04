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
	[Table("Menus")]
	public class Menu : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		[StringLength(80)]
		public string Nombre { get; set; } //(varchar(80), not null)
		[Required]
		[StringLength(300)]
		public string Descripcion { get; set; } //(varchar(300), not null)
		[Required]
		[DataType(DataType.Currency)]
		public decimal Precio { get; set; } //(money, not null)
		[Required]
		public string Imagen { get; set; } //(nvarchar(max), not null)
		[Required]
		public DateTime FechaVigencia { get; set; } //(datetime, not null)

	}
}
