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
	[Table("Entradas")]
	public class Entrada : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		public int ProductoId { get; set; } //(int, not null)
		[Required]
		public int ProveedorId { get; set; } //(int, not null)
		[Required]
		public DateTime FechaEntrada { get; set; } //(datetime, not null)
		[Required]
		public int Cantidad { get; set; } //(int, not null)
		[DataType(DataType.Currency)]
		public decimal Costo { get; set; } //(money, null)
	}
}
