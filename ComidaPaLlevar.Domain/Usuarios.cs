using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComidaPallevar.Domain
{
	/// <summary>
	/// Autor: Novatek
	/// Comentarios: Clases de datos
	/// </summary>
	[Table("Usuarios")]
	public class Usuarios : Base.BaseObjectDomain
	{
		[Required]
		[Key, Column(Order=0)]
		public int Id { get; set; } //(int, not null)
		[Required]
		[StringLength(300)]
		public string Nombre { get; set; } //(varchar(300), not null)
		[Required]
		[StringLength(150)]
		public string Email { get; set; } //(varchar(150), not null)
		[Required]
		[StringLength(18)]
		public string Telefono { get; set; } //(varchar(18), not null)

        [Required]
        [StringLength(100)]
        public string Password { get; set; } //(varchar(18), not null)
	}
}
