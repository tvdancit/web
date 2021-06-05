using DataContext.DataMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.Login;

namespace tdtt.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var acc = new AccountSQL().getInfo(sessions.UserName);
          
            return View();
        }
    }
}