using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _17T1021107NguyenDucHuy.ViewModel
{
    public partial class AppModel : DbContext
    {
        public AppModel()
            : base("name=AppModel1")
        {
        }

        public virtual DbSet<DanhBa> DanhBas { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
