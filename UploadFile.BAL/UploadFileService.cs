using System.Collections.Generic;
using System.IO;
using UploadFile.BAL.Models;

namespace UploadFile.BAL
{
    public class UploadFileService
    {
        public IList<Stream> StreamsFileList;
        public static bool UploadFile(FileModel model, Stream streamChunck)
        {
            UploadFileMyService.UploadFileServiceClient client = new UploadFileMyService.UploadFileServiceClient();
            var u = new UploadFileMyService.UploadFileModel()
            {
                IdFile = model.IdFile,
                NameFile = model.NameFile,
                IssueTracking = 99,
                PhoneNumber = model.PhoneNumber,
                Date = model.Date,
                FileSize = model.FileSize,
                NumberOfChunck = model.NumberOfChunck,
            };
           
           

            client.SaveFile(u);
            return true;
        }

        //public static bool SendListStreamToWCF(UploadFileMyService.UploadFileModel model)
        //{
        //    UploadFileMyService.UploadFileServiceClient client = new UploadFileMyService.UploadFileServiceClient();

        //    client.CollectStream(model);
        //    return true;
        //}

        public static bool SendModelStreamToWCF(Stream model)
        {
            UploadFileMyService.UploadFileServiceClient client = new UploadFileMyService.UploadFileServiceClient();

            client.CollectStream(model);
            return true;
        }

        public static bool SumStreamToWCF()
        {
            UploadFileMyService.UploadFileServiceClient client = new UploadFileMyService.UploadFileServiceClient();
            client.SumChunk();
   
            return true;
        }


    }
}
