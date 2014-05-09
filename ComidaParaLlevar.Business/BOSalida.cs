using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Dal.Implementation;

namespace ComidaPaLlevar.Business
{
    public class BOSalida
    {
        public List<Salida> RecuperarSalidas()
        {
            SalidaDaoImpl salidaDaoImpl = new SalidaDaoImpl();
            return salidaDaoImpl.SelectAll();
        }

        public Salida NuevaSalida(int Cantidad, int ProductoId, int UsuarioId, int OrdenId)
        {
            SalidaDaoImpl salidaDaoImpl = new SalidaDaoImpl();
            Salida salida = new Salida();
            salida.Cantidad = Cantidad;
            salida.FechaSolicitud = DateTime.Now;
            salida.OrdenId = OrdenId;
            salida.Precio = new BOProducto().SelectByKey(ProductoId).Precio;
            salida.Productoid = ProductoId;
            salida = salidaDaoImpl.Insert(salida);
            return salida;
        }
    }
}
