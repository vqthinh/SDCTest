using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCTest.Model.Models
{
    [Table("TinhThanh")]
    public class TinhThanh
    {
        public int ID { get; set; }

        public string TenTinhThanh { get; set; }

        public string MaVung { get; set; }

        public virtual IEnumerable<Quan> Quans { get; set; }
        
        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
    }
}
