namespace SSTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheLoai()
        {
            CheckTheLoais = new HashSet<CheckTheLoai>();
        }

        [Key]
        [DisplayName("ID Thể loại")]
        public int IDtheloai { get; set; }

        [Column("theloai")]
        [Required]
        [StringLength(50)]
        [DisplayName("Tên thể loại")]
        public string theloai1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckTheLoai> CheckTheLoais { get; set; }
    }
}
