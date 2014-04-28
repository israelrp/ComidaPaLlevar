using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ComidaPaLlevar.Models
{
    public class RegistroUsuarioModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmacion { get; set; }
    }
}