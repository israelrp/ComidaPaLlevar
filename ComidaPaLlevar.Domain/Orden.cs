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
	[Table("Ordenes")]
	public class Orden : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		public int UsuarioId { get; set; } //(int, not null)
		[Required]
		public int MenuId { get; set; } //(int, not null)
		[Required]
		public DateTime FechaSolicitud { get; set; } //(datetime, not null)
		[StringLength(50)]
		public string Comentarios { get; set; } //(varchar(50), null)
		[Required]
		public decimal Latitud { get; set; } //(decimal(18,0), not null)
		[Required]
		public decimal Longitud { get; set; } //(decimal(18,0), not null)
		[StringLength(200)]
		public string Direccion { get; set; } //(varchar(200), null)
		[Required]
		public byte Estatus { get; set; } //(tinyint, not null)

        public Menu Menu { get; set; }
	}
}
