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
    public class ServiceMenuController : ApiController
    {
        [HttpGet]
        public List<Menu> RecuperarMenus()
        {
            BOMenu boMenu = new BOMenu();
            return boMenu.RecuperarMenus();
        }

        [HttpPost]
        public Menu InsertarMenu(Menu menu)
        {
            BOMenu boMenu = new BOMenu();
            return boMenu.InsertarMenu(menu);
        }
    }
}
