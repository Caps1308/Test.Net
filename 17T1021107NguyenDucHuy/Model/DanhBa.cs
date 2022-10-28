namespace _17T1021107NguyenDucHuy.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhBa")]
    public partial class DanhBa
    {
        [Key]
        public long MaLienLac { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLienLac { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        public long MaNhom { get; set; }

        public virtual Nhom Nhom { get; set; }
    }
}
