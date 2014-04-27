using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Dal.Implementation;


namespace ComidaPaLlevar.Business
{
    public class BOOrden
    {
        public Ordenes NuevaOrden(Ordenes orden)
        {
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            return ordenesDaoImpl.Insert(orden);
        }

        public Ordenes ActualizarOrden(Ordenes orden)
        {
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            return ordenesDaoImpl.Update(orden);
        }

        public bool ActualizarEstatusOrden(int UsuarioId, int MenuId, byte EstatusOrden)
        {
            bool retorno = false;
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            Ordenes orden = ordenesDaoImpl.SelectByKey(new Ordenes { UsuarioId = UsuarioId, MenuId = MenuId });
            orden.Estatus = EstatusOrden;
            if (ordenesDaoImpl.Update(orden) != null)
            {
                retorno = true;
            }
            return retorno;
        }
    }

    public enum EstatusOrden
    {
        Abierta=0,
        EnProceso=1,
        Enviada=2,
        Entregada=3
    }
}
