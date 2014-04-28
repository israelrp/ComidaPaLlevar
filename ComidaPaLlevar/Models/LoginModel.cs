using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ComidaPaLlevar.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}