using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCTest.Model.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string HoTen { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }

        public int TinhThanhID { get; set; }

        public int QuanID { get; set; }

        [ForeignKey("TinhThanhID")]
        public virtual TinhThanh TinhThanh { get; set; }

        [ForeignKey("QuanID")]
        public virtual Quan Quan { get; set; }
    }
}
