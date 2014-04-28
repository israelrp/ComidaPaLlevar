using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Dal.Implementation;
using ComidaPallevar.Domain;

namespace ComidaPaLlevar.Business
{
    public class BOMenu
    {
        public List<Menus> RecuperarMenus()
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.SelectAll();
        }

        public Menus SelectByKey(int Id)
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.SelectByKey(new Menus { Id=Id });
        }

        public Menus InsertarMenu(Menus menu)
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.Insert(menu);
        }
    }
}
