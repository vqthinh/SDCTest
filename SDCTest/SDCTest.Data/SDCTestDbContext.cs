using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Model.Models;

namespace SDCTest.Data
{
    public class SDCTestDbContext : DbContext
    {
        public SDCTestDbContext() : base("SDCTest")
        {

        }

        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<Quan> Quans { get; set; }

        public DbSet<TinhThanh> TinhThanhs { get; set; }

        public DbSet<Error> Errors { get; set; }
    }
}
