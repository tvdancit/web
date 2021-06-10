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
        AccountSQL sql = new AccountSQL();
        // show tat ca tai khoan
        public ActionResult Index(string seach, int page = 1, int pagesize = 30)
        {
            var model = sql.getListAcc(seach, page, pagesize);
            ViewBag.seaching = seach;
            return View(model);
        }
        // them tai khoan- ham insert

        public ActionResult FormInsert()
        {
            Setlist();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            Setlist();
            return View();
        }
        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var res = sql;
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

        public ActionResult Edit(string id)
        {
            Setlist();
            var model = sql.DetailbyUser(id);
            ViewBag.User = id;
            return View(model);
        }
        public ActionResult Update(AccountModel model)
        {
            var update = sql.UpdateAccount(model.Username, model.Access, model.Status);
            if (update == true)
                ModelState.AddModelError("", "Cập Nhật Thành Công");
            else ModelState.AddModelError("", "Cập Nhật Lỗi");
            return RedirectToAction("index");
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
        [HttpDelete]
        public ActionResult delete(string id)
        {
            bool res = sql.delete(id);


            return RedirectToAction("index");


        }
        
        public ActionResult reset(string id)
        {
            sql.reset(id);
            return RedirectToAction("index");
        }
    }
}