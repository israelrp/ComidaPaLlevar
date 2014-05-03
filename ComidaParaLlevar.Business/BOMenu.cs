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

        public List<Menus> RecuperarMenuDia()
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.SelectAll().Where(x=>x.FechaVigencia.Day==DateTime.Now.Day && x.FechaVigencia.Month==DateTime.Now.Month && x.FechaVigencia.Year==DateTime.Now.Year).ToList();
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

        public Menus ActualizarMenu(Menus menu)
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.Update(menu);
        }

        public bool EliminarMenu(int Id)
        {
            MenusDaoImpl menuDaoImpl = new MenusDaoImpl();
            return menuDaoImpl.Delete(new Menus { Id = Id });
        }
    }
}
