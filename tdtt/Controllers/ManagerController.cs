using DataContext.DataMethod;
using DataContext.DataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tdtt.Models.File;
using Type = DataContext.DataTable.Type;

namespace tdtt.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        #region
        // quản lý bảng điểm
        public ActionResult Point()
        {
            ViewBag.file = new PointSQL().getFileList();
            ViewBag.Type = new PointSQL().getType();
            var model = new PointSQL().GetPoints();
            return View(model);
        }
        // thêm loại nhiệm vụ
        #region
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdTy = new PointSQL().getType();
            return View();
        }

        [HttpPost]
        public ActionResult Create(PointTable table)
        {
            return View();
        }
        #endregion
        // thêm lĩnh vực
        #region
        [HttpGet]
        public ActionResult CreateType()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateType(Type data)
        {

            return View();
        }
        #endregion
        #endregion
        // Thêm file  quy chế tính điểm cho năm học mới
        #region
        [HttpGet]
        public ActionResult addFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addFile(FileData data, HttpPostedFileBase FileName)
        {
            if (FileName != null && FileName.ContentLength > 0)
            {
                string filename = System.IO.Path.GetFileName(FileName.FileName);

                string url = Server.MapPath("~/FileFolder/Bang-Diem/" + filename);
                if (System.IO.File.Exists(url) == false)
                {
                    data.FileName = filename.ToString();
                    new PointSQL().addFilePoint(data);
                    FileName.SaveAs(url);
                }
                else
                {
                    data.FileName = "1" + filename.ToString();
                    new PointSQL().addFilePoint(data);
                    url = Server.MapPath("~/FileFolder/Bang-Diem/" + "1" + filename);
                    FileName.SaveAs(url);
                }
                return RedirectToAction("addFile");
            }
            return RedirectToAction("addFile");
        }
        #endregion
        // quản lý file 
        public ActionResult ViewFile()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("/FileFolder/Bang-diem/"));
            List<FileIO> list = new List<FileIO>();
            foreach (string filePath in filePaths)
            {
                list.Add(new FileIO { FileName = Path.GetFileName(filePath) });
            }
            return View(list);
        }
        // báo cáo, thông báo
        #region
        #region
        public ActionResult Notification()
        {
            var model = new StatementSQL().GetStatements();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateNotifi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNotifi( Notification data,HttpPostedFileBase fileName)
        {
            if (fileName != null && fileName.ContentLength > 0)
            {
                string filename = System.IO.Path.GetFileName(fileName.FileName);

                string url = Server.MapPath("~/FileFolder/Thong-bao/" + filename);
                if (System.IO.File.Exists(url) == false)
                {
                    data.FileName = filename.ToString();
                    bool res = new NotificationSQL().addNoti(data);
                    if (true == res)
                    {
                        fileName.SaveAs(url);
                        return RedirectToAction("Notification");
                    }
                    else ModelState.AddModelError("","Thử lại");
                    return View("CreateNotifi");
                   
                }
                else
                {
                    data.FileName = "1" + filename.ToString();
                    bool res = new NotificationSQL().addNoti(data);
                    if (true == res)
                    {
                        url = Server.MapPath("~/FileFolder/Thong-Bao/" + "1" + filename);
                        fileName.SaveAs(url);
                        return RedirectToAction("Notification");
                    }
                   
                }
                return RedirectToAction("addFile");
            }
            else
            {
                bool res = new NotificationSQL().addNoti(data);
                if(true== res)
                {
                    return  RedirectToAction("Notification");
                }
                else ModelState.AddModelError("", "Thử lại");
                return View("CreateNotifi");
            }    

            return View();
        }
        #endregion
        #region
        public ActionResult Statement()
        {
            var model = new StatementSQL().GetStatements();
            return View(model);
        }
        public ActionResult CreateStatement()
        {

            return View();
        }
        #endregion


        #endregion
        public ActionResult addTopic(int id)
        {
            ViewBag.Topic = new TopicLeSQL().getList();
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
            return View();
        }
        [HttpPost]
        public ActionResult addTopic(int id,string  idtp, string status)
        {

            return RedirectToAction("addTopic");
        }

    }
}