namespace UploadFile.DAL.UploadFileEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UploadFileDb : DbContext
    {
        public UploadFileDb() : base("name=UploadFileDb")

        {
        }

        public virtual DbSet<UploadFileTable> UploadFileTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
