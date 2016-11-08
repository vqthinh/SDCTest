using System.Runtime.CompilerServices;
using PagedList;
using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Data.Repositories
{
    
    public interface INhanVienRepository : IRepository<NhanVien>
    {
        //Add some external function
    }
    public class NhanVienRepository : GenericRepository<NhanVien>,INhanVienRepository
    {
        public NhanVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
