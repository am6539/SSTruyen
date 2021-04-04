namespace SSTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckTheLoai")]
    public partial class CheckTheLoai
    {
        [Key]
        public int stt { get; set; }

        public int IDtheloai { get; set; }

        [Required]
        [StringLength(50)]
        public string IDtruyen { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        public virtual Truyen Truyen { get; set; }
    }
}
