using DataContext.DataMethod;
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
       
        public ActionResult MyTopic()
        {
            LoginSession user = (LoginSession)Session["User"];
            var info = new AccountSQL().GetInformation(user.UserName);
            string id = info.IdLe;
            var model = new TopicLeSQL().GetTopicOfLectures(id);
            return View(model);
        }

        // GET: Topic/Details/5
        public ActionResult Details(string  id)
        {
            var model = new TopicLeSQL().findTopic(id);
            ViewBag.Progress = new TopicLeSQL().getProcessbyId(model.IdTp);
            return View(model);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
