namespace UploadFile.DAL.UploadFileEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UploadFileTable")]
    public partial class UploadFileTable
    {
        [Key]
        public long IdFile { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFile { get; set; }

        public short? IssueTracking { get; set; }

        public long PhoneNumber { get; set; }

        [Required]
        public byte[] FileBlanke { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        public long FileSize { get; set; }

        public long NumberOfChunck { get; set; }

    }
}
