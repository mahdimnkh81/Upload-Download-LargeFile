using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using UploadFile.BAL.Models;
using UploadFile.BAL;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace UploadFile.MVC.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View(new FileModel());
        }
        //[HttpPost]
        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> files)
        {

            Basic_Usage_Get_File_Info(files);
            return Content("");


        }
        private void Basic_Usage_Get_File_Info(IEnumerable<HttpPostedFileBase> files)
        {

            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);
                }
            }
        }

        public ActionResult SaveForm(FileModel model)
        {

            return Content("");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult FillForm(FileModel model)
        {
            ViewBag.Message = "You Should Fill this Form";



            var streamFileList = (IList)Session["StreamFileList"];
            var streamFileList2 = Session["StreamFileList"];
            model.FileSize = (long)Session["FileSize"];
            model.NumberOfChunck = (long)Session["NumberOfChuncks"];
            foreach (Stream i in streamFileList)
            {
                var w = StreamConverTOByte(i);
                UploadFileService.UploadFile(model, i);
            }
            return View();
        }

        public static byte[] StreamConverTOByte(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public ActionResult getFile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new FileModel());
        }
    }
}