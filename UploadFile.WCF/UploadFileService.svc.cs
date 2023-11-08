using System.Collections.Generic;
using System.IO;
using UploadFile.DAL.UploadFileEntity;
using UploadFile.DAL.UploadFileModel;





namespace UploadFile.WCF
{
    public class UploadFileService : IUploadFileService
    {
        public static long NumberOfChunck = 0;
        public static List<Stream> ListOfStream = new List<Stream>();

        public bool SaveFile(UploadFileModel model)
        {
            using (var db = new UploadFileDb())
            {
                var m = new UploadFileTable()
                {
                    IdFile = model.IdFile,
                    NameFile = model.NameFile,
                    IssueTracking = model.IssueTracking,
                    PhoneNumber = model.PhoneNumber,
                    FileBlanke = model.FileBlanke,
                    Date = model.Date,
                    FileSize = model.FileSize,
                    NumberOfChunck = model.NumberOfChunck   
                };
                
                if(NumberOfChunck == model.NumberOfChunck)
                {
                    db.UploadFileTables.Add(m);
                    db.SaveChanges();
                }

            }
            return true;
        }

        //public bool CollectStream(string fullPath, Stream stream)
        //{
        //    using (FileStream filestream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
        //    {
        //        using (stream)
        //        {
                    
        //            stream.CopyTo(filestream); 
        //        }
        //    }
        //    return true;
        //}

        public bool CollectStream(Stream model)
        {
            ListOfStream.Add(model);
            

            return true;
        }

        public bool SumChunk()
        {
            foreach (var stream in ListOfStream)
            {
                using (FileStream filestream = new FileStream("D:\\WCF\\UploadFile.MVC\\App_Data\\CarlSagan.pdf", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (stream)
                    {

                        stream.CopyTo(filestream);

                    }
                }
            }
            return true;
        }
    }
}
