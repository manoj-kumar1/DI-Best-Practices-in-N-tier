using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityDemo.Common;
using UnityDemo.Security;
using UnityDemo.Security.Data;

namespace UnityDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserDomain _domain;

        public HomeController(IUserDomain domain)
        {
            _domain = domain;
        }

        public ActionResult Index()
        {
            var user = _domain.GetUser(0);
            ViewBag.UserName = user.Name;

            return View();
        }

        public ActionResult UsersEdit()
        {
            var userDomain = new UserDomain(new UserData());
            var users = userDomain.GetAllUsers();

            //Or even worse
            var data = new UserData();
            var users2 = data.GetAllUsers();

            //Or even this one...Using entity framework instance
            using (var model = new SecurityModelContainer())
            {
                var users3 = from u in model.Users select u;
            }
            
            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
