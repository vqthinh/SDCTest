using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCTest.Model.Models
{
    [Table("Quan")]
    public class Quan
    {
        [Key]
        public int ID { get; set; }

        public string TenQuan { get; set; }

        public int TinhThanhID { get; set; }

        public virtual IEnumerable<NhanVien> NhanViens { get; set; }

        [ForeignKey("TinhThanhID")]
        public virtual TinhThanh TinhThanh { get; set; }
    }
}
