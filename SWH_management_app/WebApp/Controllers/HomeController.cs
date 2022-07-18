
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.DataHandle;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Repository repository = new Repository();
        public HomeController()
        {
            
        }
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (repository.Login(username, password))
            {
                return View("UserList", repository.users.AsQueryable());
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}