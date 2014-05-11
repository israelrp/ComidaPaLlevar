using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using DevExpress.Web.Mvc;


namespace ComidaPaLlevar.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        public AdministracionController()
            : this(new UserManagerAdministrator(new UserStore<Models.AdministratorUser>()))
        {

        }

        public AdministracionController(UserManagerAdministrator userManager)
        {
            UserManager = userManager;
        }

        public UserManagerAdministrator UserManager { get; private set; }



        //
        // GET: /Administracion/
        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return View();
        }

        public ActionResult Ordenes()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(Models.LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(loginModel.Email, loginModel.Password);
                if (user != null)
                {
                    await SingInAsync(user, false);
                    return RedirectToLocal("");
                }                
            }

            return View();
        }



        public RedirectToRouteResult LogOut()
        {
            var authentication = HttpContext.GetOwinContext().Authentication;
            authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Administracion");
        }

        #region Aplicaciones auxiliares para autenticación
        private IAuthenticationManager AutheticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public async Task SingInAsync(Models.AdministratorUser user, bool isPersistent)
        {
            AutheticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AutheticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Administracion");
            }
        }
        #endregion


    }

    public class UserManagerAdministrator : UserManager<Models.AdministratorUser>
    {
        public UserManagerAdministrator(IUserStore<Models.AdministratorUser> store)
            : base(store)
        {

        }

        public override async Task<Models.AdministratorUser> FindAsync(string userName, string password)
        {
            if (userName == "administracion@comoenksa.com" && password == "N0v@Tek")
            {
                return await Task.Run(() => new Models.AdministratorUser
                {
                    UserName=userName,
                    Id=userName
                });
            }
            return null;
        }

        public override async Task<ClaimsIdentity> CreateIdentityAsync(Models.AdministratorUser user, string authenticationType)
        {
            IList<Claim> claimCollection = new List<Claim>{
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Country, "México"),
                new Claim(ClaimTypes.Email, user.UserName),  
            };
            var claimsIdentity = new ClaimsIdentity(claimCollection, authenticationType);
            return await Task.Run(() => claimsIdentity);
        }
    }
}