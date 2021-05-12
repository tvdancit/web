using DataContext.DataMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.Account;
using tdtt.Models.Login;

namespace tdtt.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        [HttpGet]
        public ActionResult FormChange()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Change(ChangePasswordModel model)
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var acc = new AccountSQL().FindByUser(sessions.UserName, HashMD5.MD5Hash(model.oldpass));
            if (acc == true)
            {
                if (model.newpass1 == model.newpass2)
                {
                    var change = new AccountSQL().ChangePassword(sessions.UserName, HashMD5.MD5Hash(model.newpass1));
                    if (change == true)
                    {
                        ModelState.AddModelError("", "Đổi Mật Khẩu Thành Công");
                    }
                    else
                        ModelState.AddModelError("", "Lỗi!!! Vui Lòng Thử Lại Sau");
                }
                else
                    ModelState.AddModelError("", "Mật Khẩu Mới Chưa Khớp");
            }
            else
                ModelState.AddModelError("", "Bạn Đã Nhập Sai Mật Khẩu");
            return View("FormChange");
        }
        public ActionResult getInfobySession()
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var model = new AccountSQL().getInfo(sessions.UserName);
            if (model.Count > 0)
            {
                return View(model);
            }
            else
                return View("Infomation");

        }
        public ActionResult Infomation()
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var model = new AccountSQL().getInfo(sessions.UserName);
            if (model.Count > 0)
            {
                return View(model);
            }
            else
                return View();
        }
    }
}