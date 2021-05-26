using DataContext.DataMethod;
using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.Account;


namespace tdtt.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin

        // show tat ca tai khoan
        public ActionResult Index(string seach, int page = 1, int pagesize = 30)
        {
            var model = new AccountSQL().getListAcc(seach, page, pagesize);
            ViewBag.seaching = seach;
            return View(model);
        }
        // them tai khoan- ham insert
        public ActionResult FormInsert()
        {
            Setlist();
            return View();
        }
        public ActionResult Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var res = new AccountSQL();
                if (res.FindByUser(model.Username) == false)
                {
                    res.InsertAcc(model.Username, HashMD5.MD5Hash(model.Password), model.Access);
                    ModelState.AddModelError("", "Thêm Tài Khoản Thành Công");
                }
                else
                    ModelState.AddModelError("", "Tài Khoản Đã Tồn Tại");

            }
            return RedirectToAction("FormInsert");
        }
        // edit tai khoan
        #region
        public ActionResult FormEdit(string id)
        {
            Setlist();
            var model = new AccountSQL().DetailbyUser(id);
            ViewBag.User = id;
            return View(model);
        }
        public ActionResult Update(AccountModel model)
        {
            var update = new AccountSQL().UpdateAccount(model.Username, model.Access, model.Status);
            if (update == true)
                ModelState.AddModelError("", "Cập Nhật Thành Công");
            else ModelState.AddModelError("", "Cập Nhật Lỗi");
            return RedirectToAction("FormEdit");
        }
        #endregion
        public void Setlist()
        {

            ViewBag.Access = new List<SelectListItem>{
                       new SelectListItem { Value = "0" , Text = "Admin" },
                       new SelectListItem { Value = "1" , Text = "Phòng Nghiên Cứu Khoa Học" },
                        new SelectListItem { Value = "2" , Text = "Giảng Viên" },
                         new SelectListItem { Value = "1" , Text = "Sinh Viên" }
            };
            ViewBag.Status = new List<SelectListItem> {
                       new SelectListItem { Value = "0" , Text = "Hoat động" },
                       new SelectListItem { Value = "1" , Text = "Vô hiệu Hóa" }
            };

        }
    }
}