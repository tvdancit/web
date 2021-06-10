using DataContext.DataMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.Login;

namespace tdtt.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = new AccountSQL().Login(model.Username, HashMD5.MD5Hash(model.Password));

                if (res == true)
                {

                    var ses = new AccountSQL().GetByUser(model.Username);
                    Session["user"] = ses;
                    var userSess = new LoginSession();
                    userSess.UserName = ses.UserName;
                    userSess.Type = ses.Access;
                    Session["type"] = ses.Access;
                    Session.Add(StaticSession.USER, userSess);
                    Session.Timeout = 30;
                    if (userSess.Type == 0)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (userSess.Type == 1)
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else if (userSess.Type == 2)
                    {
                        return RedirectToAction("Mytopic", "topic");
                    }
                    else
                    {
                        ModelState.AddModelError("", "???????????????");

                    }

                }
                else ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");

            }
            return View("Index");
        }
        // dang xuat
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return View("Index");
        }
    }
}