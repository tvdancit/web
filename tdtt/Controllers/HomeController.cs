using DataContext.DataMethod;
using DataContext.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tdtt.Controllers
{
    public class HomeController : Controller
    {
        // show danh sach de tai va chuc nang tim kiem de tai
        public ActionResult Index()
        {
            
            ViewBag.ListLe = new TopicLeSQL().getListAll();
            
            return View();
        }

        // hien thi thong bao va chi tiet thong bao
        #region
        public ActionResult Notification()
        {
            ViewBag.Notifications = new NotificationSQL().getListNoti();
            return View();
        }

        public ActionResult DetailNo(long id)
        {
            if(id == null)
            {
                RedirectToAction("Notification");
            }    
            ViewBag.Notifications = new NotificationSQL().NotificationById(id);
            ViewBag.Detail = new NotificationSQL().GetDetails(id);
            return View();
        }
       
        public FileResult Download(string filename)
        {
            var FileVirtualPath = "~/FileFolder/Thong-bao/" + filename;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
        #endregion
        // đăng ký đe tai cho sinh vien
        #region
        public ActionResult CreateTopicStd(string id)
        {
            ViewBag.Type = new PointSQL().GetTypes();
            ViewBag.Point = new PointSQL().GetPoints(id);
           
            return View();
        }
        public ActionResult create(TopicSt st)
        {
            string ii = "STD-" + st.IdP + "-000000";
            string i = new TopicStdSQL().getLastTopicStd(st.IdP).ToString();
            string id = ii.Substring(0, ii.Length - i.Length) + i;
            var result = new TopicStdSQL().AddTopicStd(st,id);
            if(result==true)
            {
                string path = Server.MapPath("~/FileFolder/De-tai/" + id);
                Directory.CreateDirectory(path);
                Response.Write("<script LANGUAGE='JavaScript' >alert('Đăng ký thành công')</script>");
                return RedirectToAction("Index");
            }
            return RedirectToAction("CreateTopicStd");
        }
        #endregion
    }


}