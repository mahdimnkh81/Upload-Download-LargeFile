using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace UploadFile.DAL.UploadFileModel
{
    [DataContract]
    public class UploadFileModel
    {

        [DataMember]
        public long IdFile { get; set; }

        [DataMember]
        public string NameFile { get; set; }

        [DataMember]
        public short? IssueTracking { get; set; }

        [DataMember]
        public long PhoneNumber { get; set; }

        [DataMember]
        public byte[] FileBlanke { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public long FileSize { get; set; }

        [DataMember]
        public long NumberOfChunck { get; set; }

        [DataMember]
        public Stream StreamFile { get; set; }

        [DataMember]
        public List<Stream> streamListFile { get; set; }
    }
}
