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
	[Table("Salidas")]
	public class Salida : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		public int Productoid { get; set; } //(int, not null)
		[Required]
		public int OrdenId { get; set; } //(int, not null)
		[Required]
		[DataType(DataType.Currency)]
		public decimal Precio { get; set; } //(money, not null)
		[Required]
		public DateTime FechaSolicitud { get; set; } //(datetime, not null)
		[Required]
		public int Cantidad { get; set; } //(int, not null)
	}
}
