
using DataContext.DataMethod;
using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.Login;

namespace tdtt.Controllers
{
    public class TopicController : BaseController
    {
        // GET: Topic
        public Information Information()
        {
            LoginSession user = (LoginSession)Session["User"];
            var info = new AccountSQL().GetInformation(user.UserName);
            return info;
        }
        public ActionResult MyTopic(string i = null, string ii = null, string date1 = null, string date2 = null)
        {

            ViewBag.Type = new PointSQL().GetTypes();
            ViewBag.Point = new PointSQL().GetPoints(i);
            string id = Information().IdLe;
            var model = new TopicLeSQL().GetTopicOfLectures(id);
            return View(model);
        }

        // GET: Topic/Details/5
        public ActionResult Details(string id)
        {
            var model = new TopicLeSQL().findTopic(id);
            ViewBag.Progress = new TopicLeSQL().getProcessbyId(model.IdTp);
            return PartialView(model);
        }
        public FileResult Download(string id, string filename)
        {
            var FileVirtualPath = "~/FileFolder/De-tai/" + id + "/" + filename;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

        // GET: Topic/Create
        public ActionResult SignUpTopic(bool Issucess = false)
        {
            ViewBag.issucess = Issucess;
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult SignUp(TopicmdLe topic)
        {
            if (ModelState.IsValid)
            {
                string i = new TopicLeSQL().getLastId(topic.IdP).ToString();
                string ii = "LECT-" + topic.IdP + "000000";
                string id = ii.Substring(0, ii.Length - i.Length) + i;
                bool res = new TopicLeSQL().create(topic, id, Information().IdLe);
                if (true == res)
                {
                    return RedirectToAction("SignUpTopic", new { Issucess = true });
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công. Thử lại !!!");

                }
            }
            return RedirectToAction("SignupTopic", new { Issucess = false });
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(string id)
        {
            var model = new TopicLeSQL().getTopic(id);
            ViewBag.Point = new PointSQL().GetPoints(null);
            return View(model);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(TopicOfLecture topic)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult CreateProg(string id)
        {
            ViewBag.Status = new List<SelectListItem>{
                             new SelectListItem { Value = "Báo Cáo Lần 1" , Text = "Báo Cáo Lần 1" },
                             new SelectListItem { Value = "Báo Cáo Lần 2" , Text = "Báo Cáo Lần 2" },
                             new SelectListItem { Value = "Báo Cáo Lần 3" , Text = "Báo Cáo Lần 3" },
                             new SelectListItem { Value = "Báo Cáo Lần 4" , Text = "Báo Cáo Lần 4" },
                             new SelectListItem { Value = "Báo Cáo Lần 5" , Text = "Báo Cáo Lần 5" },
                             new SelectListItem { Value = "Báo Cáo Lần 6" , Text = "Báo Cáo Lần 6" },
                             new SelectListItem { Value = "Báo Cáo Lần 7" , Text = "Báo Cáo Lần 7" },
                             new SelectListItem { Value = "Báo Cáo Lần 8" , Text = "Báo Cáo Lần 8" },
                             new SelectListItem { Value = "Báo Cáo Lần 9" , Text = "Báo Cáo Lần 9" },
                             new SelectListItem { Value = "Báo Hoàn Thành" , Text = "Báo Cáo Hoàn Thành" }
                };

            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProg(string id,ProgressLe progress, HttpPostedFileBase fileName)
        {
            progress.IdTp = id;
            if(fileName!=null&& fileName.ContentLength>0)
            {
                string filename = System.IO.Path.GetFileName(fileName.FileName);
                progress.FileName = filename.ToString();
                string url = Server.MapPath("~/FileFolder/De-tai/" + progress.IdTp +"/"+ filename);
                fileName.SaveAs(url);
                
                
            }
            bool res = new TopicLeSQL().UpProg(progress);
            if (true == res)
            {
                return RedirectToAction("mytopic");
            }
            else
                ModelState.AddModelError("", "Thất bại, thử lại");
            return RedirectToAction("CreateProg");
            
        }
        public ActionResult partialViewFile(string path)

        {
            return PartialView();
        }
    }
}
