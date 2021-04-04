namespace SSTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChapTruyen")]
    public partial class ChapTruyen
    {
        [Key]
        public int stt { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên truyện")]
        public string IDtruyen { get; set; }

        [DisplayName("Số thứ tự chap")]
        public int chap { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Chap")]
        public string tenchap { get; set; }

        [DisplayName("Nội dung chap")]
        public string noidung { get; set; }

        public virtual Truyen Truyen { get; set; }
    }
}
