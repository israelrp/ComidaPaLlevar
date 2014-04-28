using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComidaPallevar.Domain;
using ComidaPaLlevar.Business;

namespace ComidaPaLlevar.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            List<Menus> menus = new BOMenu().RecuperarMenus();
            return View(menus);
        }

        [HttpPost]
        public ActionResult Index(int Id)
        {
            
        }
	}
}