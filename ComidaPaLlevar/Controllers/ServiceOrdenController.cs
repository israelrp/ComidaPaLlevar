using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComidaPaLlevar.Domain;
using ComidaPaLlevar.Business;

namespace ComidaPaLlevar.Controllers
{
    public class ServiceOrdenController : ApiController
    {
        public Orden NuevaOrden(Orden orden)
        {
            return new BOOrden().NuevaOrden(orden);
        }

        
    }
}
