using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComidaPaLlevar.Domain;
using System.ComponentModel.DataAnnotations;

namespace ComidaPaLlevar.Models
{
    public class ListaOrden
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<CantidadProducto> CantidadesProducto { get; set; }

        [StringLength(50)]
        public string Comentarios { get; set; } //(varchar(50), null)

        [StringLength(200)]
        public string Direccion { get; set; } //(varchar(200), null)

        public int UsuarioId { get; set; }

        public decimal ImporteTotal { get; set; }
    }

    public class CantidadProducto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
    }
}