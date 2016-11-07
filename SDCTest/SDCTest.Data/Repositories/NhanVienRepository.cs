using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Data.Repositories
{
    public class NhanVienRepository : GenericRepository<NhanVien>
    {
        public NhanVienRepository(SDCTestDbContext context) : base(context)
        {
        }
    }
}
