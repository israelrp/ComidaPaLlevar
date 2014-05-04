using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComidaPaLlevar.Dal.Implementation;
using ComidaPaLlevar.Domain;

namespace ComidaPaLlevar.Business
{
    public class BOMenu
    {
        public List<Menu> RecuperarMenus()
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.SelectAll();
        }

        public List<Menu> RecuperarMenuDia()
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.SelectAll().Where(x=>x.FechaVigencia.Day==DateTime.Now.Day && x.FechaVigencia.Month==DateTime.Now.Month && x.FechaVigencia.Year==DateTime.Now.Year).ToList();
        }

        public Menu SelectByKey(int Id)
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.SelectByKey(new Menu { Id=Id });
        }

        public Menu InsertarMenu(Menu menu)
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.Insert(menu);
        }

        public Menu ActualizarMenu(Menu menu)
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.Update(menu);
        }

        public bool EliminarMenu(int Id)
        {
            MenuDaoImpl menuDaoImpl = new MenuDaoImpl();
            return menuDaoImpl.Delete(new Menu { Id = Id });
        }
    }
}
