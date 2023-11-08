using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UploadFile.BAL;

namespace UploadFile.MVC.Controllers
{
    public partial class UploadController : Controller
    {
        public static int totalChunk = 7;
        public static int index = 0;

        [DataContract]
        public class ChunkMetaData
        {
            [DataMember(Name = "uploadUid")]
            public string UploadUid { get; set; }
            [DataMember(Name = "fileName")]
            public string FileName { get; set; }
            [DataMember(Name = "relativePath")]
            public string RelativePath { get; set; }
            [DataMember(Name = "contentType")]
            public string ContentType { get; set; }
            [DataMember(Name = "chunkIndex")]
            public long ChunkIndex { get; set; }
            [DataMember(Name = "totalChunks")]
            public long TotalChunks { get; set; }
            [DataMember(Name = "totalFileSize")]
            public long TotalFileSize { get; set; }
        }

        public class FileResult
        {
            public bool uploaded { get; set; }
            public string fileUid { get; set; }
        }


        public ActionResult ChunkUpload()
        {
            return View();
        }

        public void AppendToFile(string fullPath, Stream stream)
        {
            var x = fullPath;
            var w = stream.GetType();
            try
            {
                using (FileStream filestream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (stream)
                    {

                        stream.CopyTo(filestream);
                        //SendChunk(stream, b);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public void SendChunk(Stream stream,int a)
        {
            var x = stream;


            byte[] bytes;
            using (var reader = new StreamReader(x))
            {
                bytes = System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            //MemoryStream streamm = new MemoryStream();
            //streamm.Write(bytes, 0, bytes.Length);



            //BAL.UploadFileMyService.UploadFileModel model = new BAL.UploadFileMyService.UploadFileModel();
            //model.StreamFile = stream;
            //UploadFileService.SendModelStreamToWCF(model); 



            //TempFileClass.AddItem(stream);
            //TempFileClass.AddItemInt(a);

            //Session["StreamFileList"] = TempFileClass.GetList();
            //var x = Session["StreamFileList"];


        }
            
            
            

        //public ActionResult SendChunk()

        public ActionResult Chunk_Upload_Save(IEnumerable<HttpPostedFileBase> files, string metaData)
        {

            //if (metaData == null)
            //{
            //    return Chunk_Upload_Async_Save(files);
            //}

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(metaData));
            var serializer = new DataContractJsonSerializer(typeof(ChunkMetaData));
            ChunkMetaData chunkData = serializer.ReadObject(ms) as ChunkMetaData;

            string path = String.Empty;
            //var c = chunkData.FileName;
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    path = Path.Combine(Server.MapPath("~/App_Data"), "CarlSagan.pdf");
                    //path = Path.Combine(Server.MapPath("~/App_Data"), chunkData.FileName);
                    TempFileClass.AddItem(file.InputStream);
                    AppendToFile(path, file.InputStream);
                    
                }
            }
           
            FileResult fileBlob = new FileResult();
            //var s = chunkData.ChunkIndex;
            //fileBlob.uploaded = chunkData.TotalChunks - 1 <= chunkData.ChunkIndex;
            fileBlob.uploaded = totalChunk - 1 <= index;
            index += 1;
            //if (fileBlob.uploaded)
            //{
            //    //SumStream(path);
            //}
            fileBlob.fileUid = chunkData.UploadUid;
            //fileBlob.fileUid = "0eae0967-a0ec-4244-8b68-a329c10747f5";

            return Json(fileBlob);
        }

        private void SumStream(string fullPath)
        {
            BAL.UploadFileMyService.UploadFileServiceClient client = new BAL.UploadFileMyService.UploadFileServiceClient();
            BAL.UploadFileMyService.UploadFileModel model = new BAL.UploadFileMyService.UploadFileModel();
            model.streamListFile = TempFileClass.GetList().ToArray();
            model.NameFile = "dssssssss";
            foreach (var i in TempFileClass.GetList())
            {
                UploadFileService.SendModelStreamToWCF(i);
            }
            UploadFileService.SumStreamToWCF();
            //var listStream = TempFileClass.GetList();
            //foreach (var stream in listStream)
            //{
            //    using (FileStream filestream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            //    {
            //        using (stream)
            //        {

            //            stream.CopyTo(filestream);

            //        }
            //    }
            //}
        }

        //public ActionResult Chunk_Upload_Remove(string[] fileNames)
        //{
        //    // The parameter of the Remove action must be called "fileNames"

        //    if (fileNames != null)
        //    {
        //        foreach (var fullName in fileNames)
        //        {
        //            var fileName = Path.GetFileName(fullName);
        //            var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

        //            // TODO: Verify user permissions

        //            if (System.IO.File.Exists(physicalPath))
        //            {
        //                // The files are not actually removed in this demo
        //                // System.IO.File.Delete(physicalPath);
        //            }
        //        }
        //    }

        //    // Return an empty string to signify success
        //    return Content("");
        //}

        //public ActionResult Chunk_Upload_Async_Save(IEnumerable<HttpPostedFileBase> files)
        //{
        //    // The Name of the Upload component is "files"
        //    if (files != null)
        //    {
        //        foreach (var file in files)
        //        {
        //            // Some browsers send file names with full path.
        //            // We are only interested in the file name.
        //            var fileName = Path.GetFileName(file.FileName);
        //            var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

        //            // The files are not actually saved in this demo
        //            // file.SaveAs(physicalPath);
        //        }
        //    }

        //    // Return an empty string to signify success
        //    return Content("");
        //}
    }
}