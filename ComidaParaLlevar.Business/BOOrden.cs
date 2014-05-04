using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Dal.Implementation;

namespace ComidaPaLlevar.Business
{
    public class BOOrden
    {
        public Orden BuscarOrdenDelDia(int UsuarioId)
        {
            Orden ordenesUsuario=new Orden();
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            ordenesUsuario = ordenesDaoImpl.SelectAll().Where(x => x.UsuarioId == UsuarioId && x.FechaSolicitud.Day==DateTime.Now.Day && x.FechaSolicitud.Month==DateTime.Now.Month).FirstOrDefault();
            return ordenesUsuario;
        }

        public Orden NuevaOrden(Orden orden)
        {
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            return ordenesDaoImpl.Insert(orden);
        }

        public List<Orden> RecuperarOrdenes()
        {
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            return ordenesDaoImpl.SelectAll();
        }

        public Orden ActualizarOrden(Orden orden)
        {
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            return ordenesDaoImpl.Update(orden);
        }

        public bool EliminarOrden(int UsuarioId, int MenuId)
        {
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            return ordenesDaoImpl.Delete(new Orden { MenuId=MenuId, UsuarioId=UsuarioId });
        }

        public bool ActualizarEstatusOrden(int UsuarioId, int MenuId, byte EstatusOrden)
        {
            bool retorno = false;
            OrdenDaoImpl ordenesDaoImpl = new OrdenDaoImpl();
            Orden orden = ordenesDaoImpl.SelectByKey(new Orden { UsuarioId = UsuarioId, MenuId = MenuId });
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
