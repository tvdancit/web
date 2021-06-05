using DataContext.DataMethod;
using DataContext.DataTable;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
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
        public ActionResult MyTopic()
        {

            string id = Information().IdLe;
            var model = new TopicLeSQL().GetTopicOfLectures(id);
            return View(model);
        }

        // GET: Topic/Details/5
        public ActionResult Details(string id)
        {
            var model = new TopicLeSQL().findTopic(id);
            ViewBag.Progress = new TopicLeSQL().getProcessbyId(model.IdTp);
            return View(model);
        }

        // GET: Topic/Create
        public ActionResult SignUpTopic( bool Issucess= false)
        {
            ViewBag.issucess = Issucess;
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult SignUp(TopicmdLe topic)
        {
            if(ModelState.IsValid)
            {
                string i = new TopicLeSQL().getLastId(topic.IdP).ToString();
                string ii = "LECT-" + topic.IdP + "000000";
                string id = ii.Substring(0,ii.Length - i.Length) + i;
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
            return RedirectToAction("SignupTopic",new { Issucess =false});
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(string id)
        {
            var model = new TopicLeSQL().getTopic(id);

            return View(model);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
    }
}
