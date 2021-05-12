using DataContext.DataMethod;
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
        public ActionResult Notification()
        {
            ViewBag.Notifications = new NotificationSQL().getListNoti();
            return View();
        }

        public ActionResult DetailNo(long id)
        {
            ViewBag.Notifications = new NotificationSQL().NotificationById(id);
            ViewBag.Detail = new NotificationSQL().GetDetails(id);
            return View();
        }
       
        public FileResult Download(string filename)
        {
            var FileVirtualPath = "~/FileFolder/Thong-bao/" + filename;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }

    
}