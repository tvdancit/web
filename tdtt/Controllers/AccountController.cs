using DataContext.DataMethod;
using DataContext.DataTable;
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

        //thông tin tài khoản
        public ActionResult Index()
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var model = new AccountSQL().getInfo(sessions.UserName);
            if (model != null)
            {
                return View(model);
            }
            else
                setlist();
            return View("Check");

        }
        // đồi mật khẩu
        #region
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
                        return RedirectToAction("Index");
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
        #endregion
        //kiemr tra thông tin có thì về trang thông tin chưa thì về trang cập nhật
        #region
        public ActionResult Check()
        {
            return View();

        }
        #endregion
        // cập nhật sửa đổi thông tin
        #region
        public ActionResult UpdateInfo()
        {
            LoginSession sessions = (LoginSession)Session["user"];
            var model = new AccountSQL().GetInformation(sessions.UserName);
            setlist();
            return View(model);
        }
        public ActionResult Update(Information information)
        {
            LoginSession sessions = (LoginSession)Session["user"];
            bool res = new AccountSQL().Update(information, sessions.UserName);
            if (res == false)
            {
                ModelState.AddModelError("", "Lỗi");
            }
            else
                return RedirectToAction("Index");
            return RedirectToAction("UpdateInfo");

        }
        #endregion
        public void setlist()
        {
            var list = new DepartmentSQL().GetDepartments();
            ViewBag.IdKhoa = new SelectList(list, "IdKhoa", "Name", null);
        }
    }
}