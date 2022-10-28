namespace _17T1021107NguyenDucHuy.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhom")]
    public partial class Nhom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhom()
        {
            DanhBas = new HashSet<DanhBa>();
        }

        [Key]
        public long MaNhom { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhBa> DanhBas { get; set; }
    }
}
