namespace SSTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Truyen")]
    public partial class Truyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Truyen()
        {
            ChapTruyens = new HashSet<ChapTruyen>();
            CheckTheLoais = new HashSet<CheckTheLoai>();
        }

        [Key]
        [StringLength(50)]
        public string IDTruyen { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên truyện")]
        public string tentruyen { get; set; }

        [StringLength(50)]
        [DisplayName("Tác giả")]
        public string tacgia { get; set; }

        [StringLength(50)]
        [DisplayName("Nguồn truyện")]
        public string nguon { get; set; }

        [DisplayName("Trạng thái")]
        public bool? trangthai { get; set; }
        [DisplayName("Lượt yêu thích")]
        public int? yeuthich { get; set; }
        [DisplayName("Giới thiệu")]
        public string gioithieu { get; set; }
        
        [StringLength(50)]
        [DataType(DataType.Upload)]
        [Display(Name = "Ảnh hiển thị")]
        public string anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChapTruyen> ChapTruyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckTheLoai> CheckTheLoais { get; set; }
    }
}
