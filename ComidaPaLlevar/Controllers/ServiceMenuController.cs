using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Business;

namespace ComidaPaLlevar.Controllers
{
    public class ServiceMenuController : ApiController
    {
        [HttpGet]
        public List<Menus> RecuperarMenus()
        {
            BOMenu boMenu = new BOMenu();
            return boMenu.RecuperarMenus();
        }

        [HttpPost]
        public Menus InsertarMenu(Menus menu)
        {
            BOMenu boMenu = new BOMenu();
            return boMenu.InsertarMenu(menu);
        }
    }
}
