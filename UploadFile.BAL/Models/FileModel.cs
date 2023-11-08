using System;
using System.Collections.Generic;
using System.IO;

namespace UploadFile.BAL.Models
{
    public class FileModel
    {

        public long IdFile { get; set; }

        public string NameFile { get; set; }

        public string IssueTracking { get; set; }

        public long PhoneNumber { get; set; }

        public byte[] FileBlanke { get; set; }

        public long FileSize { get; set; }

        public string Date { get; set; }

        public long NumberOfChunck { get; set; }

        //public Stream[] StreamsFile { get; set; }

        public FileModel(long idFile, string nameFile, string issueTracking, long phoneNumber, byte[] fileBlanke, long numberOfChunck)
        {
            IdFile = idFile;
            NameFile = nameFile;
            IssueTracking = issueTracking;
            PhoneNumber = phoneNumber;
            FileBlanke = fileBlanke;
            Date = DateTime.Now.ToString();
            NumberOfChunck = numberOfChunck;
        }

        public FileModel()
        {
            Date = DateTime.Now.ToString();
        }
    }

}
