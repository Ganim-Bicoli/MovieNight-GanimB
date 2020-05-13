using System;
using MovieNight.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieNight.Controllers
{
    public class UserController : Controller
    {
        MovieNightDBEntities3 db = new MovieNightDBEntities3();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.UserLogIn login)  //detta kod-stycke hämtades från Jan-olofs videoexempel på inloggning med databas.
        {
            bool validUser = false;
            validUser = checkUser(login.username, login.password);

            if (validUser == true)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(login.username, false); // false = måste logga in varje gång
            }
            return View();
        }

        public bool checkUser(string namnIn, string passIn)
        {
            var User = from userInfo in db.UserTable
                            where
                            userInfo.Username == namnIn &&
                            userInfo.Password == passIn
                            select userInfo;
            if (User.Count() == 1)
            {
                return true;
            }

            return false;
        }

    }
}