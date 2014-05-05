using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Dal.Implementation;
using ComidaPaLlevar.Domain;

namespace ComidaPaLlevar.Business
{
    public class BOProducto
    {
        public List<Producto> RecuperarProductos()
        {
            return new ProductoDaoImpl().SelectAll().Where(x => x.Disponible == true).OrderByDescending(x=>x.Id).ToList();
        }

        public Producto SelectByKey(int ProductoId)
        {
            return new ProductoDaoImpl().SelectByKey(new Producto { Id=ProductoId });
        }
    }
}
