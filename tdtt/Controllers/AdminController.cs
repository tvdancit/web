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
            return View("FormAccount");
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
            return View("FormEdit");
        }
        #endregion
        // quyen tuy cap
        public ActionResult QTC()
        {
            var model = new AccesSQL().ListAc();
            return View(model);
        }
        public ActionResult FormtAccess()
        {
            ViewBag.tbacc = new AccesSQL().ListAc();
            return View();
        }
        public ActionResult Add(Access access)
        {
            int id = new AccesSQL().getLastAcces();
            access.id = id + 1;
            var res = new AccesSQL().createAccess(access);
            if(res>0)
            {
                ModelState.AddModelError("", "Thêm Thành Công");

            }
            else ModelState.AddModelError("", "Lỗi");

            return View("FormtAccess");
        }
        public void Setlist()
        {
            var model = new AccesSQL().ListAc();
            ViewBag.Access = new SelectList(model, "Id", "Name", null);
            ViewBag.Status = new List<SelectListItem> {
                       new SelectListItem { Value = "0" , Text = "Hoat động" },
                       new SelectListItem { Value = "1" , Text = "Vô hiệu Hóa" }, };

        }
    }
}