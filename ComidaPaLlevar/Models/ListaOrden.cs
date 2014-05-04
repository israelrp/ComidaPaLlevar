using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComidaPaLlevar.Domain;

namespace ComidaPaLlevar.Models
{
    public class ListaOrden
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<CantidadProducto> CantidadesProducto { get; set; }
    }

    public class CantidadProducto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
    }
}