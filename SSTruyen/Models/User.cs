namespace SSTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Tên tài khoản")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }
    }
}
