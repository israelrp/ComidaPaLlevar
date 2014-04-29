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

        public List<Ordenes> RecuperarOrdenes()
        {
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            return ordenesDaoImpl.SelectAll();
        }

        public Ordenes ActualizarOrden(Ordenes orden)
        {
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            return ordenesDaoImpl.Update(orden);
        }

        public bool EliminarOrden(int UsuarioId, int MenuId)
        {
            OrdenesDaoImpl ordenesDaoImpl = new OrdenesDaoImpl();
            return ordenesDaoImpl.Delete(new Ordenes { MenuId=MenuId, UsuarioId=UsuarioId });
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

        public List<EstatusOrden> RecuperarEstatusOrden()
        {
            List<EstatusOrden> estatus = new List<EstatusOrden>();
            estatus.Add(new EstatusOrden { Codigo=0, Nombre="Abierta" });
            estatus.Add(new EstatusOrden { Codigo = 1, Nombre = "En proceso" });
            estatus.Add(new EstatusOrden { Codigo = 2, Nombre = "Enviada" });
            estatus.Add(new EstatusOrden { Codigo = 3, Nombre = "Entregada" });
            return estatus;
        }

        
    }

    public class EstatusOrden
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public enum EstatusOrdenEnum
    {
        Abierta=0,
        EnProceso=1,
        Enviada=2,
        Entregada=3
    }
}
